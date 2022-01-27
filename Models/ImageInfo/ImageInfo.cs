using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecImage.Models
{
    public class ImageInfo
    {
        public ImageInfo()
        {
            ImageTransforms = new List<Transform>();
        }
        public ImageInfo(string name)
        {
            ImageTransforms = new List<Transform>();
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public int ImageUserId { get; set; }
        public User? ImageUser { get; set; }
        public IEnumerable<Transform> ImageTransforms { get; set; }
    }
}