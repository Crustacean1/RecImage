using RecImage.Repositories;
using RecImage.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecImage.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase{
        private readonly ILogger _logger;
        private readonly RepositoryManager _repositoryManager;
        public ImageController(ILogger<ImageController> logger,RepositoryManager manager){
            _logger = logger;
            _repositoryManager = manager;
        }
        [HttpGet("{userId}/{metaId}")]
        public ActionResult<MetaDataDto> getMetaFromUserById(int userId,int metaId){
            _logger.LogInformation("Endpoint reached");
            return new MetaDataDto();
        }
    }
}