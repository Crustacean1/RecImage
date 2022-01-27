using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;

namespace RecImage.Models{
    public class Transform{
        [Key]
        public int Id{get;set;}
        public int ImageInfoId{get;set;}
        public ImageInfo? OriginalImage{get;set;}
        public bool Completed{get;set;}
        public Transform(){
            Completed = false;
        }
    }
}