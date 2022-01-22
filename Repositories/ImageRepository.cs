using RecImage.Models;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RecImage.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public ImageRepository() { }
        private string generateUniqueFilename(ImageInfo imageInfo)
        {
            return Convert.ToString(imageInfo.ImageUserId) + "+" + Convert.ToString(imageInfo.Id);
        }
        public string GetFullPath(ImageInfo info, bool filtered)
        {
            return Path.ChangeExtension(Path.Join(Directory.GetCurrentDirectory(), "images/", filtered ? "output" : "source", generateUniqueFilename(info)), info.Extension);
        }

        public async Task SaveImage(IFormFile image, ImageInfo info)
        {
            bool filtered = false;
            var filePath = GetFullPath(info, filtered);
            using (Stream newFile = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(newFile);
            }
        }
        public async Task SaveImage(Image image, ImageInfo info)
        {
            bool filtered = true;
            var filePath = GetFullPath(info, filtered);
            await image.SaveAsync(filePath);
        }
        public void UpdateImageInfo(IFormFile image, ImageInfo info)
        {
            info.Extension = Path.GetExtension(image.FileName);
        }
        public void DeleteImage(ImageInfo infoOfImageToDelete)
        {
            var sourcePath = GetFullPath(infoOfImageToDelete, false);
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }
            var outputPath = GetFullPath(infoOfImageToDelete, true);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }
        public bool ImageExists(ImageInfo imageInfo, bool filtered)
        {
            var imagePath = GetFullPath(imageInfo, filtered);
            return File.Exists(imagePath);
        }
        public Image<Rgba32>? GetImage(ImageInfo imageInfo, bool filtered)
        {
            if (!ImageExists(imageInfo, filtered))
            {
                return null;
            }
            var path = GetFullPath(imageInfo, filtered);
            var image = Image.Load<Rgba32>(path);
            return image;
        }
    }
}



