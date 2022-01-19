
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecImage.Models{
    public class MetaDataDto{
        public MetaDataDto(){}
        public MetaDataDto(MetaData meta){
            Id = meta.Id;
            OriginalFile = meta.OriginalFile;
            ModifiedFile = meta.ModifiedFile;
            Creation = meta.Creation;
            ImageHash = meta.ImageHash;
        }
        public int Id{get;set;}
        public string? OriginalFile{get;set;}
        public string? ModifiedFile{get;set;}
        public DateTime Creation{get;set;}
        public string? ImageHash{get;set;}
    }
}