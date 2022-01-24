using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Services
{
    public class ImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly RepositoryManager _repositoryManager;
        private readonly ILogger<ImageService> _logger;
        private string[] _allowedExtensions = new string[] { ".png", ".bmp", ".jpg", ".jpeg" };
        public ImageService(ImageRepository imageRepository,RepositoryManager repositoryManager,ILogger<ImageService> logger)
        {
            _logger = logger;
            _imageRepository = imageRepository;
            _repositoryManager = repositoryManager;
        }
        public async Task SaveImage(IFormFile image, ImageInfo imageInfo)
        {
            if (_imageRepository.ImageExists(imageInfo, false))
            {
                return;
            }
            await _imageRepository.SaveImage(image, imageInfo);
        }
        public async Task SaveImage(Image image, ImageInfo imageInfo)
        {
            if (_imageRepository.ImageExists(imageInfo, true))
            {
                return;
            }
            await _imageRepository.SaveImage(image, imageInfo);
        }
        public string GetImagePath(ImageInfo info)
        {
            if (!_imageRepository.ImageExists(info, true))
            {
                if (!_imageRepository.ImageExists(info, false))
                {
                    return null;
                }
                return _imageRepository.GetFullPath(info, false);
            }
            return _imageRepository.GetFullPath(info, true);
        }
        public bool CheckExtension(string? extension)
        {
            if (extension == null) { return false; }
            return _allowedExtensions.Contains(extension);
        }
        public void UpdateImageInfo(IFormFile file, ImageInfo info)
        {
            _imageRepository.UpdateImageInfo(file, info);
        }
        public async Task<ImageInfo> CreateImage(IFormFile image,User user, string name)
        {
            _logger.LogInformation("Now creating image: " + name);
            var imageInfo = new ImageInfo();
            UpdateImageInfo(image, imageInfo);
            if (!CheckExtension(imageInfo.Extension))
            {
                throw new InvalidDataException("Invalid extension");
            }
            _repositoryManager.ImageInfo.CreateImageInfo(user.UserId, imageInfo);
            await _repositoryManager.SaveChangesAsync();

            await SaveImage(image, imageInfo);
            return imageInfo;
        }
        public async Task RemoveImage(ImageInfo imageInfo){
            _imageRepository.DeleteImage(imageInfo);
            _repositoryManager.ImageInfo.DeleteImageInfo(imageInfo);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}