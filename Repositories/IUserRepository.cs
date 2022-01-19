using RecImage.Models;
namespace RecImage.Repositories{
    public interface IUserRepository{
        void AddUser(User user);
        User? GetUserByLogin(string Login,bool noTrack);
        User? GetUserById(int id);
        Task<List<User>> GetAllUsers();
    }
}