using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using RecImage.Models;

namespace RecImage.Logic
{
    public class WobbleFilter : IFilter
    {
        private int _maxHarmonic = 200;
        private int _minHarmonic = 50;
        private int _basicOffset = 15;
        private int[] _harmonics;
        public WobbleFilter()
        {
            _harmonics = generateHarmonics(5);
        }
        private int[] generateHarmonics(int n)
        {
            var freqList = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < n; ++i)
            {
                freqList.Add((rnd.Next() % (_maxHarmonic-_minHarmonic)) + _minHarmonic);
            }
            return freqList.ToArray();
        }
        private int computeOffset(int height)
        {
            double totalOffset = 0;
            double buffor;
            double freq = 400;
            double lowPass = 0;
            double highPass = 100;
            foreach (var harmonic in _harmonics)
            {
                buffor = height;
                buffor/=freq;
                totalOffset += harmonic * Math.Sin(buffor) * ((freq+highPass)/(freq+lowPass));
                freq -= 80;
            }
            return (int)totalOffset;
        }
        public void FilterImage(Image<Rgba32> image)
        {
            var bufferSpan = new Span<Rgba32>(new Rgba32[image.Width]);
            for (int y = 0; y < image.Height; ++y)
            {
                var rowSpan = image.GetPixelRowSpan(y);
                rowSpan.CopyTo(bufferSpan);
                var offset = (computeOffset(y) + image.Width)%image.Width;
                var left = bufferSpan.Slice(0,offset);
                var right = bufferSpan.Slice(offset);
                left.CopyTo(rowSpan.Slice(image.Width-offset));
                right.CopyTo(rowSpan.Slice(0,image.Width-offset));
            }
        }
    }
}