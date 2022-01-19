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
        public async Task<ActionResult<List<UserResultDto>>> GetAllUsers(){
            var users = await _repoManager.Users.GetAllUsers();
            List<UserResultDto> usersWithDto = users.Select<User,UserResultDto>(u => {return new UserResultDto(u ,u.Images.Select(i => new MetaDataDto(i)).ToList());}).ToList();
            return usersWithDto;
        }
        [HttpGet("{id}")]
        public ActionResult<UserResultDto> GetUser(int id){
            var user = _repoManager.Users.GetUserById(id);
            if(user == null){
                return StatusCode(404);
            }
            var userResponse = new UserResultDto(user,user.Images.Select(i => new MetaDataDto(i)).ToList());
            return userResponse;
        }
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] UserRegistrationDto user){
            if(!ModelState.IsValid){
                return StatusCode(422);
            }
            var newUser = new Models.User(user);
            _logger.LogInformation("New login : " + user.Login);
            _repoManager.Users.AddUser(newUser);
            await _repoManager.SaveChangesAsync();
            return newUser;
        }
    }
}