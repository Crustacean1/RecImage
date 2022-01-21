using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RecImage.Logic{
    public class InverseFilter : IFilter{
        public Image<Rgba32> FilterImage(Image<Rgba32> image){

            for(var y = 0;y<image.Height;++y){
                var row = image.GetPixelRowSpan(y);
            }
            return image;
        }
    }
}