using Microsoft.EntityFrameworkCore;
using RecImage.Models;

namespace RecImage.Repositories{
    public class RepositoryContext : DbContext{
        public RepositoryContext(DbContextOptions options) : base(options){
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var userConf = new UserConfiguration();
            modelBuilder.UseCollation("utf8_general_ci");
            userConf.Configure(modelBuilder);
        }
        public DbSet<User>? Users{get;set;}
        public DbSet<ImageInfo>? ImageInfo{get;set;}
        public DbSet<Transform>? Transforms{get;set;}
    
    }
}