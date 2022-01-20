using RecImage.Models;
namespace RecImage.Repositories{
    public class ImageInfoRepository : IImageInfoRepository{
        private readonly  RepositoryContext _context;
        public ImageInfoRepository(RepositoryContext context){
            _context = context;
        }
        public ImageInfo GetImageInfo(int id,bool trackChanges){
            return _context.ImageInfo.Where(i => i.Id == id).FirstOrDefault();
        }
        public ICollection<ImageInfo> GetAllImageInfo(int userId, bool trackChanges){
            if(_context == null || _context.ImageInfo == null){
                return new List<ImageInfo>();
            }
            return _context.ImageInfo.Where(i=> i.ImageUserId == userId).ToList();
        }

        public void CreateImageInfo(int userId,ImageInfo newImage){
            newImage.ImageUserId = userId;
            _context.ImageInfo.Add(newImage);
        }
        public void DeleteImageInfo(ImageInfo imageInfo){
           _context.Remove(imageInfo);
        }
    }
}