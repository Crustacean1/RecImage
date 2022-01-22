using RecImage.Models;
using RecImage.Repositories;

namespace RecImage.Services{
    public class UserService{
        private readonly RepositoryManager _repositoryManager;
        public UserService(RepositoryManager repositoryManager){
            _repositoryManager = repositoryManager;
        }
        public bool AuthorizeUser(int userId, int imageInfoId){
            return true;
        }
        public void RegisterUser(UserRegistrationDto user){
            
        }
    }
}