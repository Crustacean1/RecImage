using Microsoft.EntityFrameworkCore;
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
        public User? GetUserByLogin(string Login, bool noTrack)
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
            //builder.Entity<MetaData>().HasOne(m => m.).WithMany( u => u.Images);
            List<User> users = new List<User>{
                new User
                {
                    Login = "kamil@crustacean.pl",
                    UserId = 1
                },
                new User
                {
                    Login = "limak@naecatsurc.lp",
                    UserId = 2
                }
            };
            List<ImageInfo> metaData = new List<ImageInfo>{
                        new ImageInfo{
                            Id = 1,
                            ImageUserId = 1,
                            IsUploaded = false,
                            Name = "ladybug"
                        },
                        new ImageInfo{
                            Id = 2,
                            ImageUserId = 1,
                            IsUploaded = false,
                            Name = "frog"
                        },
                        new ImageInfo {
                            Id = 3,
                            ImageUserId = 1,
                            IsUploaded = false,
                            Name = "pepe"
                        }
            };
            builder.Entity<User>().HasData(users);
            builder.Entity<ImageInfo>().HasData(metaData);
        }
    }
}