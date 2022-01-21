using Microsoft.AspNetCore.Mvc;
using RecImage.Repositories;
using System.Collections.Concurrent;
using System.Threading.Channels;
using SixLabors.ImageSharp;

namespace RecImage.Logic
{
    public class ImageProcessorService : BackgroundService
    {
        private readonly ILogger<ImageProcessorService> _logger;
        private readonly Channel<Job> _jobQueue;
        private readonly ConcurrentDictionary<int, Job> _jobDict;
        private List<Task<Job>> _imageProcessingTasks;
        private int _threadCountLimit = 5;

        public ImageProcessorService(ILogger<ImageProcessorService> logger)
        {
            _logger = logger;
            _jobQueue = Channel.CreateUnbounded<Job>();
            _jobDict = new ConcurrentDictionary<int, Job>();
            _imageProcessingTasks = new List<Task<Job>>();
        }
        public async Task<int> AddNewJob(Job imageJob)
        {
            await _jobQueue.Writer.WriteAsync(imageJob);
            _logger.LogInformation("Writen to queue");
            var jobId = _jobDict.Count();
            _jobDict.Append(new KeyValuePair<int, Job>(jobId, imageJob));
            return jobId;
        }
        public Job GetJob(int jobId)
        {
            if (!_jobDict.ContainsKey(jobId))
            {
                return null;
            }
            return _jobDict[jobId];
        }
        private static Job ProcessImage(Job imageJob, IEnumerable<IFilter> filters)
        {
            Thread.Sleep(5000);
            return new Job();
            //return await Task.Delay(100);
        }
        private void StartJob(Job newJob)
        {
            if (newJob == null) { return; }
            Task<Job> task = new Task<Job>(() => ProcessImage(newJob, new List<IFilter>()));
            _imageProcessingTasks.Add(task);
            task.Start();
            _logger.LogInformation("Adding new task");
        }
        private async Task DequeueJobs()
        {
            for (int i = 0; _imageProcessingTasks.Count() < _threadCountLimit && _jobQueue.Reader.TryRead(out Job? newJob); ++i)
            {
                StartJob(newJob);
            }
        }
        protected async override Task ExecuteAsync(CancellationToken token)
        {
            _logger.LogInformation("Starting background execution");
            while (!token.IsCancellationRequested)
            {
                if (_imageProcessingTasks.Count == 0)
                {
                    var newJob = await _jobQueue.Reader.ReadAsync();
                    StartJob(newJob);
                }

                int taskIndex = Task.WaitAny(_imageProcessingTasks.ToArray(), token);
                Job newImage = await _imageProcessingTasks[taskIndex];
                _imageProcessingTasks.RemoveAt(taskIndex);

                DequeueJobs();
            }
        }
        public override async Task StopAsync(CancellationToken token)
        {
            await base.StopAsync(token);
        }
    }
}