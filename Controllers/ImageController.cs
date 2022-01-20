using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase{
        private readonly RepositoryManager _repositoryManager;
        private string GetContentType(ImageInfo imageInfo){
            if(imageInfo.Extension == null){
                throw new FormatException();
            }
            return "image/"+imageInfo.Extension.Substring(1);
        }
        public ImageController(RepositoryManager repositoryManager){
            _repositoryManager = repositoryManager;
        }
        [HttpPost]
        public ActionResult ApplyFilters(){
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetImage(int id){
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(id,trackChanges: false);
            var imagePath = _repositoryManager.Images.GetFullPath(imageInfo,true);// First try filtered image
            if(!_repositoryManager.Images.ImageExists(imageInfo,true)){
                imagePath = _repositoryManager.Images.GetFullPath(imageInfo,false);// Fall back to original
                if(!_repositoryManager.Images.ImageExists(imageInfo,false)){
                    return NotFound();// no image available, fail
                }
            }
            var fullPath = Path.Join(Directory.GetCurrentDirectory(),imagePath);
            var mimeProvider = new FileExtensionContentTypeProvider().TryGetContentType(fullPath,out var mimeExtension);
            return PhysicalFile(fullPath,mimeExtension,imageInfo.Name);
        }
        [HttpGet]
        public ActionResult GetAllFilters(){
            return Ok();
        }
        [HttpPost]
        public ActionResult ApplyFilter(){
            return Ok();
        }
    }
}