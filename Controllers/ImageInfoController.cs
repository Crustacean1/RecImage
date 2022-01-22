using RecImage.Repositories;
using RecImage.Models;
using Microsoft.AspNetCore.Mvc;
using RecImage.Services;

namespace RecImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageInfoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RepositoryManager _repositoryManager;
        private readonly ImageRepository _imageRepository;
        private readonly AuthorizationService _authService;

        public ImageInfoController(ILogger<ImageInfoController> logger,AuthorizationService authService,ImageRepository imageRepository, RepositoryManager manager)
        {
            _logger = logger;
            _repositoryManager = manager;
            _imageRepository = imageRepository;
            _authService = authService;
        }
        [HttpGet("{id}")]
        public ActionResult<ImageInfoResponseDto> getImageInfoById(int id)
        {
            var image = _authService.AuthorizeImageAccess(Request.Headers,id);
            if(image == null){
                return NotFound();
            }
            return new ImageInfoResponseDto(image);
        }
        [HttpGet]
        public ActionResult<ICollection<ImageInfoResponseDto>> GetAllImageInfoFromUser()
        {
            var user = _authService.GetUserFromHeader(Request.Headers);
            if(user == null){
                return NotFound();
            }
            var rawImages = _repositoryManager.ImageInfo.GetAllImageInfo(user.UserId);
            var resultImages = rawImages.Select(i => new ImageInfoResponseDto(i));
            return resultImages.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<ImageInfoResponseDto>> CreateNewImageInfo([FromBody] ImageInfoRequestDto newImageDto)
        {
            var user = _authService.GetUserFromHeader(Request.Headers);
            if (user == null)
            {
                return NotFound();
            }
            var newImage = new ImageInfo(newImageDto);
            _repositoryManager.ImageInfo.CreateImageInfo(user.UserId, newImage);
            await _repositoryManager.SaveChangesAsync();
            return new ImageInfoResponseDto(newImage);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            var user = _authService.GetUserFromHeader(Request.Headers);
            if (user == null)
            {
                return NotFound();
            }
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id);
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