using Microsoft.AspNetCore.Mvc;
using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase{

        private readonly ILogger _logger;
        private readonly RepositoryManager _repoManager;
        public UserController(ILogger<UserController> logger, RepositoryManager manager){
            _logger = logger;
            _repoManager = manager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResultDto>>> GetCrap(){
            if(_repoManager == null){
                _logger.LogInformation("Empty repo manager");
                return StatusCode(500);
            }
            var users = (await _repoManager.Users.GetAllUsers()).Select(u => new UserResultDto(u));
            return users;
        }
        [HttpPost]
        public ActionResult<User> RegisterUser(UserRegistrationDto user){
            return NoContent();
        }
    }
}