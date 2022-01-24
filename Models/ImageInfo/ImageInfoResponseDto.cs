namespace RecImage.Models{
    public class ImageInfoResponseDto{
        public ImageInfoResponseDto(){}
        public ImageInfoResponseDto(ImageInfo meta){
            Id = meta.Id;
            Name = meta.Name;
        }
        public int Id{get;set;}
        public string? Name{get;set;}
    }
}