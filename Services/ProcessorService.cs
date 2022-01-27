using RecImage.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Logic;
using RecImage.Models;
using System.Collections.Concurrent;

namespace RecImage.Services
{
    public class ProcessorService
    {
        private readonly RepositoryManager _repoManager;
        private readonly ILogger<ProcessorService> _logger;
        private readonly ImageRepository _imageRepo;
        private string[] _allowedExtensions = new string[] { ".png", ".bmp", ".jpg", ".jpeg" };

        public ProcessorService(RepositoryManager repoManager, ILogger<ProcessorService> logger, ImageRepository imageRepository)
        {
            _imageRepo = imageRepository;
            _repoManager = repoManager;
            _logger = logger;
        }
        public async Task TransformImage(Job imageJob)
        {
            Image<Rgba32>? image = await _imageRepo.GetSourceImage(imageJob.SourceImageInfo);
            if (image == null || imageJob.Filters == null)
            {
                return;
            }
            Task imageProcessing = new Task(() => ApplyFilters(image, imageJob.Filters));
            imageProcessing.Start();
            try
            {
                await imageProcessing;
            }
            catch (Exception e)
            {
                return;
            }
            await FinalizeProcessing(imageJob.SourceImageInfo, image);
            return;
        }
        public async Task<ImageInfo> CreateNewImage(IFormFile image, User user, string name)
        {
            _logger.LogInformation("Now creating image: " + name);
            var imageInfo = new ImageInfo(name);
            UpdateImageInfo(image, imageInfo);

            if (!CheckExtension(imageInfo.Extension))
            {
                throw new InvalidDataException("Invalid extension");
            }

            _repoManager.ImageInfo.CreateImageInfo(user.UserId, imageInfo);
            await _repoManager.SaveChangesAsync();
            await _imageRepo.SaveNewImage(image, imageInfo);

            var job = new Job();
            job.Filters = new List<IFilter>();
            job.SourceImageInfo = imageInfo;
            await TransformImage(job);
            return imageInfo;
        }
        public async Task DeleteImage(ImageInfo imageInfo)
        {
            var allTransformFiles = GetAllTransformFilenames(imageInfo);
            var sourceImage = _imageRepo.GetSourcePath(imageInfo);
            _repoManager.ImageInfo.DeleteImageInfo(imageInfo);
            await _repoManager.SaveChangesAsync();

            DeleteAbandonedFiles(allTransformFiles);
            _imageRepo.DeleteImage(sourceImage);
        }
        private async Task FinalizeProcessing(ImageInfo imageInfo, Image<Rgba32> image)
        {
            //Create unfinished transform and save file
            var transform = CreateNewTransformEntry(imageInfo);
            await _repoManager.SaveChangesAsync();

            //Delete old transforms and complete latest transform
            await SaveImage(image, transform);
            var oldImages = GetOldTransformFilenames(transform);
            await CleanUpOldTransformEntries(transform);
            DeleteAbandonedFiles(oldImages);
            await _repoManager.SaveChangesAsync();
        }
        private void ApplyFilters(Image<Rgba32> image, IEnumerable<IFilter> filters)
        {
            foreach (var filter in filters)
            {
                filter.FilterImage(image);
                _logger.LogInformation("Processing image");
                if (image == null)
                {
                    _logger.LogInformation("Filter failed to process image");
                    throw new InvalidOperationException();
                }
            }
            return;
        }
        private IEnumerable<string> GetOldTransformFilenames(Transform transform)
        {
            return _repoManager.Transforms.GetOtherTransforms(transform).Select((tr) => (_imageRepo.GetOutputPath(tr))).ToList();
        }
        private IEnumerable<string> GetAllTransformFilenames(ImageInfo imageInfo){
            return _repoManager.Transforms.GetAllTransforms(imageInfo).Select(tr => _imageRepo.GetOutputPath(tr)).ToList();
        }
        private bool CheckExtension(string? extension)
        {
            if (extension == null) { return false; }
            return _allowedExtensions.Contains(extension);
        }
        private void UpdateImageInfo(IFormFile file, ImageInfo info)
        {
            _imageRepo.UpdateImageInfo(file, info);
        }
        private Transform CreateNewTransformEntry(ImageInfo imageInfo)
        {
            var transform = new Transform();
            transform.OriginalImage = imageInfo;
            _repoManager.Transforms.CreateTransform(transform);
            return transform;
        }
        private async Task SaveImage(Image<Rgba32> image, Transform transform)
        {
            await _imageRepo.SaveTransformedImage(image, transform);
            transform.Completed = true;
        }
        private async Task CleanUpOldTransformEntries(Transform transform)
        {
            _repoManager.Transforms.DeleteOtherTransforms(transform);
            await _repoManager.SaveChangesAsync();
        }
        private void DeleteAbandonedFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                _logger.LogInformation($"deleting: {file}");
                _imageRepo.DeleteImage(file);
            }
        }
    }
}