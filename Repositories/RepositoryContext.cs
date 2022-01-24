using Microsoft.EntityFrameworkCore;
using RecImage.Models;

namespace RecImage.Repositories{
    public class RepositoryContext : DbContext{
        public RepositoryContext(DbContextOptions options) : base(options){
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var userConf = new UserConfiguration();
            modelBuilder.UseCollation("latin1_general_cs");
            userConf.Configure(modelBuilder);
        }
        public DbSet<User>? Users{get;set;}
        public DbSet<ImageInfo>? ImageInfo{get;set;}
    
    }
}