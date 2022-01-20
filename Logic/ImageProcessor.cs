using RecImage.Repositories;
using RecImage.Models;
using SixLabors.ImageSharp;

namespace RecImage.Logic{
    public class ImageProcessor{

        private readonly RepositoryManager _repository;
        private readonly IFormFile _image;
        private readonly ImageInfo _imageInfo;
        public ImageProcessor(IFormFile image,ImageInfo imageInfo,RepositoryManager repository){
            _repository = repository;
            _image = image;
            _imageInfo = imageInfo;
        }
        public void Transform(){

        }
        public void Save(){
            //using(var memoryStream = new MemoryStream()){
                using(var image = Image.Load(_image.OpenReadStream())){
                    image.Save("images/quick_test.jpg");
                }
            //}
        }


    }
}