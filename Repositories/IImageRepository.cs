using RecImage.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Repositories{
    public interface IImageRepository{
        Task SaveImage(IFormFile image,ImageInfo info);
        Task SaveImage(Image image,ImageInfo info);
        void UpdateImageInfo(IFormFile image,ImageInfo info);
        void DeleteImage(ImageInfo info);
        
        bool ImageExists(ImageInfo info, bool filtered);
        string GetFullPath(ImageInfo info,bool filtered);
        Image<Rgba32>? GetImage(ImageInfo imageInfo,bool filtered);
    }
}