using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RecImage.Models;
using RecImage.Repositories;
using RecImage.Logic;

namespace RecImage.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase{
        private readonly RepositoryManager _repositoryManager;
        private readonly ImageProcessorService _imageProcessor;
        private readonly ILogger<ImageController> _logger;
        private string GetContentType(ImageInfo imageInfo){
            if(imageInfo.Extension == null){
                throw new FormatException();
            }
            return "image/"+imageInfo.Extension.Substring(1);
        }
        public ImageController(RepositoryManager repositoryManager,IServiceProvider serviceProvider,ILogger<ImageController> logger){
            _repositoryManager = repositoryManager;
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
            var imagePath = _repositoryManager.Images.GetFullPath(imageInfo,true);// First try filtered image

            _logger.LogInformation(imagePath);
            _logger.LogInformation(imageInfo.Extension);
            if(!_repositoryManager.Images.ImageExists(imageInfo,true)){
                imagePath = _repositoryManager.Images.GetFullPath(imageInfo,false);// Fall back to original
                if(!_repositoryManager.Images.ImageExists(imageInfo,false)){
                    return NotFound("Image metadata found, but no image");// no image available, fail
                }
            }
            var fullPath = Path.Join(Directory.GetCurrentDirectory(),imagePath);
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
        public async Task<ActionResult> ApplyFilter(){
            _logger.LogInformation("Aplying filter");
            await _imageProcessor.AddNewJob(new Job());
            return Ok();
        }
    }
}