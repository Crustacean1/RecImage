using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Models;

namespace RecImage.Logic{
    public interface IFilter{
        void FilterImage(Image<Rgba32> image);
    }
}