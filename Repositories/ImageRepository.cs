using RecImage.Models;
using System.IO;
using SixLabors.ImageSharp;

namespace RecImage.Repositories{
    public class ImageRepository : IImageRepository{
        public ImageRepository(){}
        private string generateUniqueFilename(ImageInfo imageInfo){
            return Convert.ToString(imageInfo.ImageUserId) + "+" + Convert.ToString(imageInfo.Id);
        }
        public string GetFullPath(ImageInfo info,bool filtered){
            return Path.ChangeExtension(Path.Join("images/", filtered ? "output" : "source", generateUniqueFilename(info)), info.Extension);
        }

        public async Task<bool> SaveImage(IFormFile image,ImageInfo info,bool filtered){
            var filePath = GetFullPath(info,filtered);
            if(File.Exists(filePath)){
                return false;
            }
            using(Stream newFile = new FileStream(filePath,FileMode.Create)){
                await image.CopyToAsync(newFile);
            }
            return true;
        }
        public bool SaveImage(Image image,ImageInfo info,bool filtered){
            var filePath = GetFullPath(info,filtered);
            if(File.Exists(filePath)){
                return false;
            }
            image.Save(filePath);
            return true;
        }
        public void UpdateImageInfo(IFormFile image,ImageInfo info){
            info.Extension = Path.GetExtension(image.FileName);
            info.Creation = DateTime.Now;
        }
        public void DeleteImage(ImageInfo infoOfImageToDelete){
            var sourcePath = GetFullPath(infoOfImageToDelete,false);
            if(File.Exists(sourcePath)){
                File.Delete(sourcePath);
            }
            var outputPath = GetFullPath(infoOfImageToDelete,true);
            if(File.Exists(outputPath)){
                File.Delete(outputPath);
            }
        }
        public bool ImageExists(ImageInfo imageInfo,bool filtered){
            var imagePath = GetFullPath(imageInfo,filtered);
            return File.Exists(imagePath);
        }
    }
}