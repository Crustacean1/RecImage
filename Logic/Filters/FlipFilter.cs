using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RecImage.Logic
{
    public class FlipFilter : IFilter
    {
        public FlipFilter()
        {

        }
        public Image<Rgba32> FilterImage(Image<Rgba32> image)
        {
            for (int y = 0; y < image.Height ; ++y)
            {
                var rowSpan = image.GetPixelRowSpan(y);
                for (int x = 0; x < image.Width/2 ; ++x)
                {
                    var leftPixel = rowSpan[x]; 
                    rowSpan[x] = rowSpan[image.Width -1 - x];
                    rowSpan[x] = rowSpan[image.Width- 1 - x];
                    rowSpan[image.Width- 1 - x] = leftPixel;
                }
            }
            return image;
        }
    }
}