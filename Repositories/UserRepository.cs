using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;
using RecImage.Models;

namespace RecImage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RepositoryContext _context;
        public UserRepository(RepositoryContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers(){
            return await _context.Users.Include(u=>u.Images).ToListAsync();
        }
        public void AddUser(User user)
        {
            _context.Add(user);
        }
        public User? GetUserByLogin(string Login)
        {
            return _context.Users.Include(u =>u.Images).Where(u => u.Login == Login).FirstOrDefault();
        }
        public User? GetUserById(int id){
            return _context.Users.Include(u => u.Images).Where(u=>u.UserId == id).FirstOrDefault();
        }
    }
    public class UserConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Transform>().HasOne( tr => tr.OriginalImage)
            .WithMany(im => im.ImageTransforms)
            .HasForeignKey(tr=>tr.ImageInfoId);
        }
    }
}