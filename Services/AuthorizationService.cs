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
            if(!headers.ContainsKey("x-recimage-id")){return null;}
            int userId = Convert.ToInt32(headers["x-recimage-id"]);
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
            throw new ArgumentException("Invalid credentials");
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
            throw new ArgumentException("Invalid credentials");
        }
        public async Task<User> RegisterUser(UserLoginDto userDto)
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
        public async Task<User?> LoginUser(UserLoginDto userLogin){
            if(userLogin == null || userLogin.Login == null){
                return null;
            }
            var user = _repositoryManager.Users.GetUserByLogin(userLogin.Login);
            if(user == null){
                return await RegisterUser(userLogin);
            }
            return user;
        }
    }
}