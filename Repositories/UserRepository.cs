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
                            OriginalFile = "ladybug_shop.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "cockroach_shop.jpg",
                            Creation = DateTime.Now,
                            Id = 1,
                            ImageUserId = 1,
                            Name = "ladybug"
                        },
                        new ImageInfo{
                            OriginalFile = "frog_shop.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "duck_shop.jpg",
                            Creation = DateTime.Now,
                            Id = 2,
                            ImageUserId = 1,
                            Name = "frog"
                        },
                        new ImageInfo {
                            OriginalFile = "pepe_the_frog.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "pepe_the_duck.jpg",
                            Creation = DateTime.Now,
                            Id = 3,
                            ImageUserId = 1,
                            Name = "4chan"
                        }
            };
            builder.Entity<User>().HasData(users);
            builder.Entity<ImageInfo>().HasData(metaData);
        }
    }
}