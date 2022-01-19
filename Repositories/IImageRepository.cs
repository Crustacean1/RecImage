using RecImage.Models;

namespace RecImage.Repositories{
    public interface IImageRepository{
        Task SaveImageToFile(IFormFile image,ImageInfo info,string dir);
    }
}