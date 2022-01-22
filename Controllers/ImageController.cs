using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RecImage.Models;
using RecImage.Repositories;
using RecImage.Logic;
using RecImage.Services;

namespace RecImage.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase{
        private readonly RepositoryManager _repositoryManager;
        private readonly ImageService _imageService;
        private readonly ImageProcessorService _imageProcessor;

        private readonly ILogger<ImageController> _logger;
        public ImageController(RepositoryManager repositoryManager,ImageService imageService,IServiceProvider serviceProvider,ILogger<ImageController> logger){
            _repositoryManager = repositoryManager;
            _imageService = imageService;
            _logger = logger;
            _imageProcessor = serviceProvider.GetServices<IHostedService>().OfType<ImageProcessorService>().FirstOrDefault();
            if(_imageProcessor == null){
                _logger.LogInformation("image processor not found, we are doomed");
            }
        }
        [HttpPost]
        public ActionResult ApplyFilters(){
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetImage(int id){
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id,trackChanges: false);
            if(imageInfo == null){
                return NotFound("No such image info found");
            }
            var fullPath = _imageService.GetImagePath(imageInfo);
            var mimeType = new string("");
            var mimeProvider = new FileExtensionContentTypeProvider().TryGetContentType(fullPath,out mimeType);
            if(mimeType == null){
                return StatusCode(500,"Couldn't infer mime type");
            }
            return PhysicalFile(fullPath,mimeType,imageInfo.Name);
        }
        [HttpGet]
        public ActionResult GetAllFilters(){
            return Ok();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> ApplyFilter(int id,IEnumerable<string> filterList){
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id,true);
            foreach(var str in filterList){
                _logger.LogInformation(str);
            }
            try{
                List<IFilter> filters = FilterFactory.buildFilters(filterList);
                await _imageProcessor.AddNewJob(new Job(imageInfo,filters));
            }catch(ArgumentException e){
                _logger.LogInformation("Failed to construct filter list");
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("{id}")]
        [RequestSizeLimit(100_100_100)]
        public async Task<ActionResult<ImageInfoResponseDto>> CreateNewImage(int id, IFormFile image)
        {
            _logger.LogInformation("User: "+ Request.Headers["x-user-id"]);
            if (!Request.Headers.ContainsKey("x-user-id"))
            {
                return Unauthorized();
            }
            var userId = Convert.ToInt32((Request.Headers["x-user-id"]));
            var user = _repositoryManager.Users.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id, trackChanges: true);
            if (imageInfo == null)
            {
                ModelState.AddModelError("id", "invalid image id");
                _logger.LogInformation("imageInfo is null");
                return BadRequest(ModelState);
            }
            if (imageInfo.ImageUserId != user.UserId)
            {
                ModelState.AddModelError("user", "unauthorized user");
                _logger.LogInformation("Unathorized upload: " + user.UserId);
                return BadRequest(ModelState);
            }
            if (imageInfo.IsUploaded)
            {
                ModelState.AddModelError("id", "image already uploaded");
                _logger.LogInformation("Image already uploaded");
                return BadRequest(ModelState);
            }
            if (image == null)
            {
                ModelState.AddModelError("sourceImage", "no file provided");
                _logger.LogInformation("source Image is null");
                return BadRequest(ModelState);
            }

            _imageService.UpdateImageInfo(image, imageInfo);
            if (!_imageService.CheckExtension(imageInfo.Extension))
            {
                return BadRequest();
            }

            _logger.LogInformation("Started saving");
            await _imageService.SaveImage(image, imageInfo);
            _logger.LogInformation("Finished saving");
            imageInfo.IsUploaded = true;
            await _repositoryManager.SaveChangesAsync();
            return new ImageInfoResponseDto(imageInfo);
        }
    }
}