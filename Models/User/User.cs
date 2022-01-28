using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace RecImage.Models{
    public class User{
        public User(){
            Images = new List<ImageInfo>();
        }
        public User(UserLoginDto user){
            Login  = user.Login;
        }
        [Key]
        public int UserId{get;set;}
        public string? Login{get;set;}
        public ICollection<ImageInfo>? Images{get;set;}
    }
}