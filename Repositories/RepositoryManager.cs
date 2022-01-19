namespace RecImage.Repositories
{
    public class RepositoryManager
    {
        private UserRepository _users;
        private RepositoryContext _context;
        public RepositoryManager(RepositoryContext context){
            _context  = context;
        }
        public UserRepository Users{
            get{
                if(_users == null){
                    _users = new UserRepository(_context);
                }
                return _users;
            }}
        public void SaveChanges(){
            _context.SaveChanges();
        }
    }
}