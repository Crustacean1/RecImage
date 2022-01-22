using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace RecImage.Models{
    public class User{
        public User(){}
        public User(string login){}
        public User(UserInfoDto user){
            Login  = user.Login;
        }
        public User(UserRegistrationDto user){
            Login  = user.Login;
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