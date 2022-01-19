using RecImage.Repositories;
using RecImage.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Controllers{
    [ApiController]
    [Route("users/{userId}/[controller]")]
    public class ImageController : ControllerBase{
        private readonly ILogger _logger;
        private readonly RepositoryManager _repositoryManager;
        public ImageController(ILogger<ImageController> logger,RepositoryManager manager){
            _logger = logger;
            _repositoryManager = manager;
        }
        [HttpGet("{metaId}")]
        public ActionResult<ImageInfoDto> getImageInfoFromUserById(int userId,int metaId){
            var user = _repositoryManager.Users.GetUserById(userId);
            if(user == null){
                return NotFound();
            }
            var image = _repositoryManager.ImageInfo.GetImageInfo(userId,metaId,trackChanges : false);
            if(image == null){
                return NotFound();
            }
            return new ImageInfoDto(image);
        }
        [HttpGet]
        public ActionResult<ICollection<ImageInfoDto>> getAllImageInfoFromUser(int userId){
            _logger.LogInformation("Get images from user: " + userId);
            var user = _repositoryManager.Users.GetUserById(userId);
            if(user == null){
                return NotFound();
            }
            var rawImages = _repositoryManager.ImageInfo.GetAllImageInfo(userId,trackChanges: false);
            var resultImages = rawImages.Select(i => new ImageInfoDto(i));
            return resultImages.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<ImageInfoDto>> createNewImageInfo(int userId,[FromBody] ImageInfoRequestDto newImageDto){
            var user = _repositoryManager.Users.GetUserById(userId);
            if(user == null){
                return NotFound();
            }
            var newImage = new ImageInfo(newImageDto);
            _repositoryManager.ImageInfo.CreateImageInfo(userId,newImage);
            await _repositoryManager.SaveChangesAsync();
            return new ImageInfoDto(newImage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ImageInfoDto>> createNewImageInfo(int userId,int id,IFormFile sourceImage){
            var user = _repositoryManager.Users.GetUserById(userId);
            if(user == null){
                return NotFound();
            }
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(userId,id,trackChanges: true);
            if(imageInfo == null){
                return NotFound();
            }
            if(sourceImage == null){
                return NotFound();
            }
            _logger.LogInformation("received: " + sourceImage.FileName);
            _logger.LogInformation("of length: " +sourceImage.Length);

            _repositoryManager.Images.SaveImageToFile(sourceImage,imageInfo,"images/source");
            //imageInfo.OriginalFileName = 
            //imageInfo.Hash = 

            return new ImageInfoDto(imageInfo);

        }
    }
}