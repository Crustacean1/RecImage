using RecImage.Models;
using SixLabors.ImageSharp;

namespace RecImage.Logic{
    public class Job{
        public ImageInfo ImageToProcess{get;set;}
        public int CompletionPercent{get;set;}
        public enum Status{
            NotAssigned,
            Queued,
            Processed,
            Done
        }
        public Status CurrentStatus{get;set;}
        public Image? ResultImage{get;set;}
        public List<IFilter> Filters{get;set;}
        public Job(ImageInfo imageInfo,List<IFilter> filters){
            Filters = filters;
            ImageToProcess = imageInfo;
            CompletionPercent = 0;
            CurrentStatus = Status.NotAssigned;
            ResultImage = null;
        }
        public Job(){}
    }
}