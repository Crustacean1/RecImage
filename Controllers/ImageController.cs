using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RecImage.Models;
using RecImage.Repositories;
using RecImage.Logic;
using RecImage.Services;

namespace RecImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly RepositoryManager _repositoryManager;
        private readonly ImageService _imageService;
        private readonly AuthorizationService _authService;
        private readonly ImageProcessorService _imageProcessor;

        private readonly ILogger<ImageController> _logger;
        public ImageController(RepositoryManager repositoryManager, AuthorizationService authService, ImageService imageService, IServiceProvider serviceProvider, ILogger<ImageController> logger)
        {
            _repositoryManager = repositoryManager;
            _imageService = imageService;
            _authService = authService;
            _logger = logger;
            _imageProcessor = serviceProvider.GetServices<IHostedService>().OfType<ImageProcessorService>().First();
        }
        [HttpGet("{id}")]
        public ActionResult GetImage(int id)
        {
            try
            {
                var imageInfo = _authService.AuthorizeImageAccess(Request.Headers, id);
                if (imageInfo == null)
                {
                    return NotFound("No such image info found");
                }
                var fullPath = _imageService.GetImagePath(imageInfo);
                var mimeType = new string("");
                var mimeProvider = new FileExtensionContentTypeProvider().TryGetContentType(fullPath, out mimeType);
                if (mimeType == null)
                {
                    return StatusCode(500, "Couldn't infer mime type");
                }
                try
                {
                    return PhysicalFile(fullPath, mimeType, imageInfo.Name);
                }catch(Exception e){
                    return NotFound("Image is being processed");
                }
            }
            catch (ArgumentException e)
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        public ActionResult GetAllFilters()
        {
            return Ok();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> ApplyFilter(int id, IEnumerable<string> filterList)
        {
            try
            {
                var imageInfo = _authService.AuthorizeImageAccess(Request.Headers, id);
                if (imageInfo == null)
                {
                    return NotFound();
                }
                try
                {
                    List<IFilter> filters = FilterFactory.buildFilters(filterList);
                    await _imageProcessor.AddNewJob(new Job(imageInfo, filters));
                }
                catch (ArgumentException e)
                {
                    _logger.LogInformation("Failed to construct filter list: " + e.ToString());
                    return BadRequest();
                }
                return Ok();
            }
            catch (ArgumentException e)
            {
                return Unauthorized();
            }
        }
        [HttpPut]
        public async Task<ActionResult<ImageInfoResponseDto>> CreateNewImage(IFormFile image, [FromForm] string name)
        {
            try
            {
                var user = _authService.GetUserFromHeader(Request.Headers);
                if (user == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Adding new image: " + name);
                var imageInfo = await _imageService.CreateImage(image, user, name);
                return new ImageInfoResponseDto(imageInfo);
            }
            catch (ArgumentException e)
            {
                return Unauthorized();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            try
            {
                var imageInfo = _authService.AuthorizeImageAccess(Request.Headers, id);
                if (imageInfo == null)
                {
                    return NotFound();
                }
                await _imageService.RemoveImage(imageInfo);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return Unauthorized();
            }
        }
    }
}