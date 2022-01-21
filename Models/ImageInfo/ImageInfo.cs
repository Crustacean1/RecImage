using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecImage.Models{
    public class ImageInfo{
        public ImageInfo(){}
        public ImageInfo(ImageInfoRequestDto requestDto){
            Name = requestDto.Name;
        }

        [Key]
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? Extension{get;set;}
        public bool IsUploaded{get;set;} = false;
        public int ImageUserId{get;set;}
        public User? ImageUser{get;set;}
    }
}