using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Models;

namespace RecImage.Logic
{
    public class FlipFilter : IFilter
    {
        public FlipFilter()
        {

        }
        public void FilterImage(Image<Rgba32> image)
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
        }
    }
}