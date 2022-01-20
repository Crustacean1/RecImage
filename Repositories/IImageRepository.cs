using RecImage.Models;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Repositories{
    public interface IImageRepository{
        Task<bool> SaveImage(IFormFile image,ImageInfo info,bool transformed);
        bool SaveImage(Image image,ImageInfo info,bool transformed);
        void UpdateImageInfo(IFormFile image,ImageInfo info);
        void DeleteImage(ImageInfo info);
        
        bool ImageExists(ImageInfo info, bool filtered);
        string GetFullPath(ImageInfo info,bool filtered);
    }
}