namespace RecImage.Models{
    public class ImageInfoResponseDto{
        public ImageInfoResponseDto(){}
        public ImageInfoResponseDto(ImageInfo meta){
            Id = meta.Id;
            Name = meta.Name;
            Extension = meta.Extension;
        }
        public int Id{get;set;}
        public string? Name{get;set;}
        public string? Extension{get;set;}
    }
}