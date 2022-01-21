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
        private static readonly string[] _allowedExtensions = { ".jpg", ".png", ".bmp" };

        public ImageInfoController(ILogger<ImageInfoController> logger, RepositoryManager manager)
        {
            _logger = logger;
            _repositoryManager = manager;
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
        public ActionResult<ICollection<ImageInfoResponseDto>> getAllImageInfoFromUser()
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
        public async Task<ActionResult<ImageInfoResponseDto>> createNewImageInfo([FromBody] ImageInfoRequestDto newImageDto)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<ImageInfoResponseDto>> createNewImageInfo(int id, IFormFile sourceImage)
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
            if (sourceImage == null)
            {
                ModelState.AddModelError("sourceImage", "no file provided");
                _logger.LogInformation("source Image is null");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repositoryManager.Images.UpdateImageInfo(sourceImage, imageInfo);
            if (!_allowedExtensions.Contains(imageInfo.Extension))
            {
                return BadRequest();
            }

            await _repositoryManager.Images.SaveImage(sourceImage, imageInfo, transformed: false);
            imageInfo.IsUploaded = true;
            _repositoryManager.SaveChanges();
            return new ImageInfoResponseDto(imageInfo);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteImage(int id)
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
            _repositoryManager.Images.DeleteImage(imageInfo);
            _repositoryManager.ImageInfo.DeleteImageInfo(imageInfo);
            _repositoryManager.SaveChanges();
            return Ok();
        }
    }
}