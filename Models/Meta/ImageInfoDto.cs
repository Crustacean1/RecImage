namespace RecImage.Models{
    public class ImageInfoDto{
        public ImageInfoDto(){}
        public ImageInfoDto(ImageInfo meta){
            Id = meta.Id;
            Name = meta.Name;
            OriginalFile = meta.OriginalFile;
            ModifiedFile = meta.ModifiedFile;
            Creation = meta.Creation;
            ImageHash = meta.ImageHash;
        }
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? OriginalFile{get;set;}
        public string? ModifiedFile{get;set;}
        public DateTime Creation{get;set;}
        public string? ImageHash{get;set;}
    }
}