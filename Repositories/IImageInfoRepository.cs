using RecImage.Models;
namespace RecImage.Repositories{
    public interface IImageInfoRepository{
        ImageInfo GetImageInfo(int id);
        ICollection<ImageInfo> GetAllImageInfo(int userId);
        void CreateImageInfo(int userId,ImageInfo newInfo);
        void DeleteImageInfo(ImageInfo imageInfo);
    }
}