using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Models;

namespace RecImage.Logic
{
    public class InverseFilter : IFilter
    {
        public InverseFilter()
        {

        }
        public void FilterImage(Image<Rgba32> image, JobInfo jobInfo)
        {
            for (int y = 0; y < image.Height ; ++y)
            {
                var rowSpan = image.GetPixelRowSpan(y);
                for (int x = 0; x < image.Width; ++x)
                {
                    var pixel = rowSpan[x];
                    rowSpan[x] = new Rgba32((byte)(255-pixel.R),(byte)(255-pixel.G),(byte)(255-pixel.B),(byte)255);
                }
                jobInfo.CompletionPercent = (int)(y*100/image.Height);
            }
        }
    }
}