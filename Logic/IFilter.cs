using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
namespace RecImage.Logic{
    public interface IFilter{
        Image<Rgba32> FilterImage(Image<Rgba32> image);
    }
}