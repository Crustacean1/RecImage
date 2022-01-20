using RecImage.Models;
namespace RecImage.Repositories{
    public interface IImageInfoRepository{
        ImageInfo GetImageInfo(int id,bool trackChanges);
        ICollection<ImageInfo> GetAllImageInfo(int userId,bool trackChanges);
        void CreateImageInfo(int userId,ImageInfo newInfo);
        void DeleteImageInfo(ImageInfo imageInfo);
    }
}