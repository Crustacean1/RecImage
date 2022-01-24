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
        [HttpGet("{id}")]
        public ActionResult<UserResultDto> GetUser(int id)
        {
            try
            {
                _logger.LogInformation("Accessing user data at: " + id);
                var user = _authService.AuthorizeUserAccess(Request.Headers, id);
                if (user == null)
                {
                    return NotFound();
                }
                var userResponse = new UserResultDto(user, user.Images.Select(i => new ImageInfoResponseDto(i)).ToList());
                return userResponse;
            }
            catch (InvalidDataException e)
            {
                _logger.LogInformation(e.ToString());
                return Unauthorized();
            }
        }
        [HttpPost]
        public async Task<ActionResult<UserResultDto>> LoginUser([FromBody] UserLoginDto user)
        {
            _logger.LogInformation("User is trying to log in");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = _authService.LoginUser(user);
            if (newUser == null)
            {
                return Unauthorized();
            }
            return new UserResultDto(newUser, newUser.Images.Select(i => new ImageInfoResponseDto(i)).ToList());
        }
    }
}