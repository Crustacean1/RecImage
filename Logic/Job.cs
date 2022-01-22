using RecImage.Models;
using SixLabors.ImageSharp;

namespace RecImage.Logic{
    public class Job{
        public JobInfo? Info{get;set;}
        public ImageInfo? SourceImageInfo{get;set;}
        public Image? ResultImage{get;set;}
        public List<IFilter>? Filters{get;set;}
        public Job(ImageInfo imageInfo,List<IFilter> filters){
            Filters = filters;
            SourceImageInfo = imageInfo;
            Info = new JobInfo();
            ResultImage = null;
        }
        public Job(){}
    }
}