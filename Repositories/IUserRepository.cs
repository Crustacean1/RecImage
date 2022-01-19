using RecImage.Models;
namespace RecImage.Repositories{
    interface IUserRepository{
        void AddUser(User user);
        User GetUserByLogin(string Login,bool noTrack);
        Task<List<User>> GetAllUsers();
    }
}