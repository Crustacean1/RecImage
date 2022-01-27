namespace RecImage.Repositories
{
    public class RepositoryManager
    {
        private IUserRepository? _users;
        private IImageInfoRepository? _imageInfo;
        private ITransformRepository? _transforms;
        //private IImageRepository _images;
        private RepositoryContext _context;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
        }
        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }
        public IImageInfoRepository ImageInfo
        {
            get
            {
                if (_imageInfo == null)
                {
                    _imageInfo = new ImageInfoRepository(_context);
                }
                return _imageInfo;
            }
        }
        public ITransformRepository Transforms
        {
            get{
                if(_transforms == null){
                    _transforms = new TransformRepository(_context);
                }
                return _transforms;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}