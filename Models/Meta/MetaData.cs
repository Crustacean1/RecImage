using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecImage.Models{
    public class MetaData{
        [Key]
        public int Id{get;set;}
        public string? OriginalFile{get;set;}
        public string? ModifiedFile{get;set;}
        public DateTime Creation{get;set;}
        public string? ImageHash{get;set;}
        public int ImageUserId{get;set;}
        public User? ImageUser{get;set;}
    }
}