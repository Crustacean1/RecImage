using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Services
{
    public class AuthorizationService
    {
        private readonly RepositoryManager _repositoryManager;
        public AuthorizationService(RepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public User? GetUserFromHeader(IHeaderDictionary headers){
            if(!headers.ContainsKey("x-user-login")){return null;}
            int userId = Convert.ToInt32(headers["x-user-login"]);
            return _repositoryManager.Users.GetUserById(userId);
        }
        public User? AuthorizeUserAccess(IHeaderDictionary headers,int accessedUserId){
            var user = GetUserFromHeader(headers);
            if (user == null)
            {
                return null;
            }
            if(user.UserId == accessedUserId){
                return user;
            }
            return null;
        }
        public ImageInfo? AuthorizeImageAccess(IHeaderDictionary headers, int imageInfoId)
        {
            var user = GetUserFromHeader(headers);
            if (user == null)
            {
                return null;
            }
            var imageInfo = _repositoryManager.ImageInfo.GetImageInfo(imageInfoId);
            if (imageInfo == null)
            {
                return null;
            }
            if(imageInfo.ImageUserId == user.UserId){
                return imageInfo;
            }
            return null;
        }
        public async Task<User> RegisterUser(UserRegistrationDto userDto)
        {
            var user = new User(userDto);
            if(userDto == null){
                throw new InvalidDataException("User dto can not be null");
            }
            if(userDto.Login == null){
                throw new InvalidDataException("You have to specify Login!");
            }
            var conflictingUsers = _repositoryManager.Users.GetUserByLogin(userDto.Login);
            if(conflictingUsers != null){
                throw new InvalidOperationException("User already exists in database");
            }
            _repositoryManager.Users.AddUser(user);
            await _repositoryManager.SaveChangesAsync();
            return user;
        }
        public User? LoginUser(UserLoginDto userLogin){
            if(userLogin == null || userLogin.Login == null){
                return null;
            }
            var user = _repositoryManager.Users.GetUserByLogin(userLogin.Login);
            return user;
        }
    }
}