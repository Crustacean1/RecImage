using RecImage.Models;
using System.IO;

namespace RecImage.Repositories{
    public class ImageRepository : IImageRepository{
        public ImageRepository(){}
        public async Task SaveImageToFile(IFormFile image,ImageInfo info,string dir){
            string uniqueFileName = System.Convert.ToString(info.ImageUserId) + "+" + System.Convert.ToString(info.Id);
            using(Stream newFile = new FileStream(Path.Join(dir,uniqueFileName),FileMode.Create)){
                await image.CopyToAsync(newFile);
            }
        }
    }
}