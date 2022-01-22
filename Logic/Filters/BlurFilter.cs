using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Models;

namespace RecImage.Logic
{
    public class BlurFilter : IFilter
    {
        public BlurFilter()
        {

        }
        private int[] SumPixels(int[] averages, Rgba32 pixel)
        {
            averages[0] += (int)pixel.R;
            averages[1] += (int)pixel.G;
            averages[2] += (int)pixel.B;
            return averages;
        }
        private Rgba32 ComputeAverage(int[] averages, int size)
        {
            int divisor = size * size;
            return new Rgba32((byte)Math.Max(Math.Min(averages[0] / divisor, 255), 0),
            (byte)Math.Max(Math.Min(averages[1] / divisor, 255), 0),
            (byte)Math.Max(Math.Min(averages[2] / divisor, 255), 0), 255);
        }
        public void FilterImage(Image<Rgba32> image, JobInfo jobInfo)
        {
            int blur = 5;
            for (int y = blur; y < image.Height - blur; ++y)
            {
                for (int x = blur; x < image.Width - blur; ++x)
                {
                    int[] averages = new int[3] { 0, 0, 0 };
                    for (int j = 0; j < blur * 2 + 1; ++j)
                    {
                        Span<Rgba32> imageRow = image.GetPixelRowSpan(y + blur - j);
                        for (int i = 0; i < blur * 2 + 1; ++i)
                        {
                            averages = SumPixels(averages, imageRow[x + blur - i]);
                        }
                    }
                    image.GetPixelRowSpan(y)[x] = ComputeAverage(averages, blur * 2 + 1);
                }
                jobInfo.CompletionPercent = (int)(100 * y /image.Height);
            }
        }
    }
}