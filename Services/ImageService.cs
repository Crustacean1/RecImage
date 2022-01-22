using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Services{
    public class ImageService{
        private readonly IImageRepository _imageRepository;
        private string[] _allowedExtensions = new string[]{".png",".bmp",".jpg",".jpeg"};
        public ImageService(ImageRepository imageRepository){
            _imageRepository = imageRepository;
        }
        public async Task SaveImage(IFormFile image,ImageInfo imageInfo){
            if(_imageRepository.ImageExists(imageInfo,false)){
                return;
            }
            await _imageRepository.SaveImage(image,imageInfo);
        }
        public async Task SaveImage(Image image,ImageInfo imageInfo){
            if(_imageRepository.ImageExists(imageInfo,true)){
                return;
            }
            await _imageRepository.SaveImage(image,imageInfo);
        }
        public string GetImagePath(ImageInfo info){
            if(!_imageRepository.ImageExists(info,true)){
                if(!_imageRepository.ImageExists(info,false)){
                    return null;     
                }
                return _imageRepository.GetFullPath(info,false);
            }
            return _imageRepository.GetFullPath(info,true);
        }
        public bool CheckExtension(string extension){
            return _allowedExtensions.Contains(extension);
        }
        public void UpdateImageInfo(IFormFile file,ImageInfo info){
            _imageRepository.UpdateImageInfo(file,info);
        }
    }
}