namespace RecImage.Models{
    public class JobInfo{
        public int CompletionPercent{get;set;}
        public enum Status{
            NotAssigned,
            Queued,
            Processed,
            Succeeded,
            Failed
        }
        public Status CurrentStatus{get;set;}

        public JobInfo(){
            CompletionPercent = 0;
            CurrentStatus = Status.NotAssigned;
        }
    }
}