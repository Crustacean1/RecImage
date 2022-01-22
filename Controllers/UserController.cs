using Microsoft.AspNetCore.Mvc;
using RecImage.Models;
using RecImage.Repositories;
using RecImage.Services;

namespace RecImage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly RepositoryManager _repoManager;
        private readonly AuthorizationService _authService;
        public UsersController(ILogger<UsersController> logger, AuthorizationService authService, RepositoryManager manager)
        {
            _logger = logger;
            _repoManager = manager;
            _authService = authService;
        }
        //Debug only
        [HttpGet]
        public async Task<ActionResult<List<UserResultDto>>> GetAllUsers()
        {
            var users = await _repoManager.Users.GetAllUsers();
            List<UserResultDto> usersWithDto = users.Select<User, UserResultDto>(u => { return new UserResultDto(u, u.Images.Select(i => new ImageInfoResponseDto(i)).ToList()); }).ToList();
            return usersWithDto;
        }
        [HttpGet("{id}")]
        public ActionResult<UserResultDto> GetUser(int id)
        {
            var user = _authService.AuthorizeUserAccess(Request.Headers, id);
            if (user == null)
            {
                _logger.LogInformation("Access denied for: " + id);
                return NotFound();
            }
            var userResponse = new UserResultDto(user, user.Images.Select(i => new ImageInfoResponseDto(i)).ToList());
            return userResponse;
        }
        [HttpPost]
        public async Task<ActionResult<User>> LoginUser([FromBody] UserLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = _authService.LoginUser(user);
            if (newUser == null)
            {
                return Forbid();
            }
            return newUser;
        }
    }
}