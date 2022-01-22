using RecImage.Repositories;
using RecImage.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageInfoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RepositoryManager _repositoryManager;
        private readonly ImageRepository _imageRepository;
        private static readonly string[] _allowedExtensions = { ".jpg", ".png", ".bmp" };

        public ImageInfoController(ILogger<ImageInfoController> logger,ImageRepository imageRepository, RepositoryManager manager)
        {
            _logger = logger;
            _repositoryManager = manager;
            _imageRepository = imageRepository;
        }
        [HttpGet("{metaId}")]
        public ActionResult<ImageInfoResponseDto> getImageInfoFromUserById(int metaId)
        {
            var image = _repositoryManager.ImageInfo.GetImageInfo(metaId, trackChanges: false);
            if (image == null)
            {
                return NotFound("No image with that id found");
            }
            if(Request.Headers["x-user-id"].Equals("")){
                return Forbid("You need to specifiy x-user-id in header");
            }
            var userId = Convert.ToInt32((Request.Headers["x-user-id"]));
            if (image.ImageUserId != userId)
            {
                return Unauthorized("You don't have access to this image");
            }
            return new ImageInfoResponseDto(image);
        }
        [HttpGet]
        public ActionResult<ICollection<ImageInfoResponseDto>> GetAllImageInfoFromUser()
        {
            if(Request.Headers["x-user-id"].Equals("")){
                return Forbid();
            }
            var userId = Convert.ToInt32((Request.Headers["x-user-id"]));
            var user = _repositoryManager.Users.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var rawImages = _repositoryManager.ImageInfo.GetAllImageInfo(userId, trackChanges: false);
            var resultImages = rawImages.Select(i => new ImageInfoResponseDto(i));
            return resultImages.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<ImageInfoResponseDto>> CreateNewImageInfo([FromBody] ImageInfoRequestDto newImageDto)
        {
            if (Request.Headers["x-user-id"].Equals(""))
            {
                return Unauthorized();
            }
            var userId = Convert.ToInt32((Request.Headers["x-user-id"]));
            var user = _repositoryManager.Users.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var newImage = new ImageInfo(newImageDto);
            _repositoryManager.ImageInfo.CreateImageInfo(userId, newImage);
            await _repositoryManager.SaveChangesAsync();
            return new ImageInfoResponseDto(newImage);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            if (Request.Headers["x-user-id"].Equals(""))
            {
                return Forbid();
            }
            var userId = Convert.ToInt32((Request.Headers["x-user-id"]));
            var user = _repositoryManager.Users.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id, trackChanges: false);
            if (imageInfo == null)
            {
                return NotFound();
            }
            _imageRepository.DeleteImage(imageInfo);
            _repositoryManager.ImageInfo.DeleteImageInfo(imageInfo);
            await _repositoryManager.SaveChangesAsync();
            return Ok();
        }
    }
}