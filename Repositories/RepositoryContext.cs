using Microsoft.EntityFrameworkCore;
using RecImage.Models;

namespace RecImage.Repositories{
    public class RepositoryContext : DbContext{
        public RepositoryContext(DbContextOptions options) : base(options){
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var userConf = new UserConfiguration();
            userConf.Configure(modelBuilder);
        }
        public DbSet<User> Users{get;set;}
        public DbSet<MetaData> MetaData{get;set;}
    
    }
}