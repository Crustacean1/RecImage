using RecImage.Models;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RecImage.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly string imageDirectory = "images";
        private readonly string sourceDirectory = "source";
        private readonly string outputDirectory = "output";
        public ImageRepository() { }
        private string CreateSourceFilename(ImageInfo imageInfo)
        {
            return Convert.ToString(imageInfo.ImageUserId) + "+"
            + Convert.ToString(imageInfo.Id);
        }
        private string CreateOutputFilename(Transform transform)
        {
            var imageInfo = transform.OriginalImage;
            return CreateSourceFilename(imageInfo) + "+"
            + Convert.ToString(transform.Id);
        }
        public string GetSourcePath(ImageInfo info)
        {
            return Path.ChangeExtension(Path.Join(Directory.GetCurrentDirectory(), imageDirectory, sourceDirectory, CreateSourceFilename(info)), info.Extension);
        }
        public string GetOutputPath(Transform transform)
        {
            var info = transform.OriginalImage;
            return Path.ChangeExtension(Path.Join(Directory.GetCurrentDirectory(), imageDirectory, outputDirectory, CreateOutputFilename(transform)), info.Extension);
        }
        public string? GetDefaultPath(Transform transform)
        {
            var outPath = GetOutputPath(transform);
            if (!File.Exists(outPath))
            {
                    return null;
            }
            return outPath;
        }

        public async Task SaveNewImage(IFormFile image, ImageInfo info)
        {
            var filePath = GetSourcePath(info);
            using (Stream newFile = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(newFile);
            }
        }
        public async Task SaveTransformedImage(Image image, Transform imageTransform)
        {
            var filePath = GetOutputPath(imageTransform);
            await image.SaveAsync(filePath);
        }
        public void UpdateImageInfo(IFormFile image, ImageInfo info)
        {
            info.Extension = Path.GetExtension(image.FileName);
        }
        public void DeleteImage(ImageInfo infoOfImageToDelete)
        {
            var sourcePath = GetSourcePath(infoOfImageToDelete);
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }
            foreach (var transform in infoOfImageToDelete.ImageTransforms) // Delete all transforms
            {
                var outputPath = GetOutputPath(transform);
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
            }
        }
        public void DeleteImage(string path){
            if(!File.Exists(path)){
                return;
            }
            File.Delete(path);
        }
        public async Task<Image<Rgba32>?> GetSourceImage(ImageInfo imageInfo)
        {
            var path = GetSourcePath(imageInfo);
            if (!File.Exists(path))
            {
                return null;
            }
            var image = await Image.LoadAsync<Rgba32>(path);
            return image;
        }
        public void DeleteTransform(Transform transform){
            var path = GetOutputPath(transform);
            if(File.Exists(path)){
                File.Delete(path);
                return;
            }
        }
    }
}



