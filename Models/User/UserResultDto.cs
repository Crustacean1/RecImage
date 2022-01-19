
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace RecImage.Models{
    public class UserResultDto{
        public UserResultDto(){}
        public UserResultDto(string login){}
        public UserResultDto(User user,ICollection<ImageInfoDto> imageMeta){
            Login  = user.Login;
            UserId = user.UserId;
            Images = user.Images.Select(i => new ImageInfoDto(i));
            Images = imageMeta;
        }
        
        public int UserId{get;set;}
        public string? Login{get;set;}
        public IEnumerable<ImageInfoDto> Images{get;set;}
    }
}