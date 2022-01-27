using RecImage.Models;
using SixLabors.ImageSharp;

namespace RecImage.Logic{
    public class Job{
        public ImageInfo? SourceImageInfo{get;set;}
        public Image? ResultImage{get;set;}
        public List<IFilter>? Filters{get;set;}
        public Job(ImageInfo imageInfo,List<IFilter> filters){
            Filters = filters;
            SourceImageInfo = imageInfo;
            ResultImage = null;
        }
        public Job(){}
    }
}