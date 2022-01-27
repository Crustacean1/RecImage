using RecImage.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Repositories
{
    public interface IImageRepository
    {
        Task SaveNewImage(IFormFile image, ImageInfo info);
        Task SaveTransformedImage(Image image, Transform transform);
        void UpdateImageInfo(IFormFile image, ImageInfo info);
        void DeleteImage(string path);
        void DeleteImage(ImageInfo info);
        void DeleteTransform(Transform transform);
        string? GetDefaultPath(Transform transform);
        Task<Image<Rgba32>?> GetSourceImage(ImageInfo imageInfo);
    }
}