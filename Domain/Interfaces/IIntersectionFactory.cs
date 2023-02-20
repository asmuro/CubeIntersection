
namespace Domain.Interfaces
{
    public interface IIntersectionFactory
    {
        IIntersectionService GetIntersectionService(IShape shape1, IShape shape2);
    }
}
