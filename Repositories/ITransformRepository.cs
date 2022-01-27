using RecImage.Models;
namespace RecImage.Repositories{
    public interface ITransformRepository{
        void DeleteTransform(int id);
        void DeleteOtherTransforms(Transform transform);
        Transform? GetTransform(int id);
        IEnumerable<Transform>? GetOtherTransforms(Transform transform);
        IEnumerable<Transform>? GetAllTransforms(ImageInfo imageInfo);
        void CreateTransform(Transform transform);
        Transform? GetLatestTransform(ImageInfo imageInfo);
    }
}