using RecImage.Models;

namespace RecImage.Repositories
{
    public class TransformRepository : ITransformRepository
    {
        private readonly RepositoryContext _context;
        public TransformRepository(RepositoryContext context)
        {
            _context = context;
        }
        public Transform? GetTransform(int id)
        {
            return _context.Transforms.Where(t => t.Id == id).FirstOrDefault();
        }
        public IEnumerable<Transform>? GetOtherTransforms(Transform transform)
        {
            return _context.Transforms.Where(t => t.ImageInfoId == transform.ImageInfoId && t.Id != transform.Id);
        }
        public void SaveTransform(Transform transform)
        {
            _context.Transforms.Add(transform);
        }
        public void DeleteTransform(int id)
        {
            var transformToDelete = GetTransform(id);
            if (transformToDelete == null)
            {
                return;
            }
            _context.Transforms.Remove(transformToDelete);
        }
        public void CreateTransform(Transform transform)
        {
            _context.Transforms.Add(transform);
        }
        public Transform? GetLatestTransform(ImageInfo imageInfo)
        {
            return _context.Transforms.Where(tr => tr.ImageInfoId == imageInfo.Id && tr.Completed).OrderBy(tr => -tr.Id).FirstOrDefault();
        }
        public void DeleteOtherTransforms(Transform transform)
        {
            var otherTransforms = _context.Transforms.Where(tr => (tr.ImageInfoId == transform.ImageInfoId
            && tr.Completed
            && tr.Id != transform.Id));
            _context.Transforms.RemoveRange(otherTransforms);
        }
        public IEnumerable<Transform>? GetAllTransforms(ImageInfo imageInfo){
            return _context.Transforms.Where(tr=>tr.ImageInfoId == imageInfo.Id);
        }
    }
}