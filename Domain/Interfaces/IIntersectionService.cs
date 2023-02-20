
namespace Domain.Interfaces
{
    public interface IIntersectionService
    {
        Task<bool> IntersectsAsync(IShape shape1, IShape shape2);
        Task<double> IntersectionVolumeAsync(IShape shape1, IShape shape2);
    }
}
