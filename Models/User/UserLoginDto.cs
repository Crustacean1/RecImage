using System.ComponentModel.DataAnnotations;

namespace RecImage.Models{
    public class UserLoginDto{
        [Required]
        public string? Login{get;set;}
    }
}