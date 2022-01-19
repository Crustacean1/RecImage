using RecImage.Models;
namespace RecImage.Repositories{
    public class MetaRepository : IMetaRepository{
        private readonly  RepositoryContext _context;
        public MetaRepository(RepositoryContext context){
            _context = context;
        }
        public MetaData getMetaData(User user,int id){
            return new MetaData();
        }
    }
}