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
            List<MetaData> metaData = new List<MetaData>{
                        new MetaData{
                            OriginalFile = "ladybug_shop.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "cockroach_shop.jpg",
                            Creation = DateTime.Now,
                            Id = 1,
                            ImageUserId = 1
                        },
                        new MetaData{
                            OriginalFile = "frog_shop.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "duck_shop.jpg",
                            Creation = DateTime.Now,
                            Id = 2,
                            ImageUserId = 1
                        },
                        new MetaData {
                            OriginalFile = "pepe_the_frog.jpg",
                            ImageHash = "hashhashhash",
                            ModifiedFile = "pepe_the_duck.jpg",
                            Creation = DateTime.Now,
                            Id = 3,
                            ImageUserId = 1
                        }
            };
            builder.Entity<User>().HasData(users);
            builder.Entity<MetaData>().HasData(metaData);
        }
    }
}