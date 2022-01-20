namespace RecImage.Models{
    public class ImageInfoResponseDto{
        public ImageInfoResponseDto(){}
        public ImageInfoResponseDto(ImageInfo meta){
            Id = meta.Id;
            Name = meta.Name;
            Creation = meta.Creation;
            Extension = meta.Extension;
            ImageHash = meta.ImageHash;
        }
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? Extension{get;set;}
        public DateTime Creation{get;set;}
        public string? ImageHash{get;set;}
    }
}