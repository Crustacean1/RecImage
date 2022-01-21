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
        Status CurrentStatus{get;set;}
        Image? ResultImage{get;set;}
        public Job(ImageInfo imageInfo){
            ImageToProcess = imageInfo;
            CompletionPercent = 0;
            CurrentStatus = Status.NotAssigned;
            ResultImage = null;
        }
        public Job(){}
    }
}