
namespace Domain.Interfaces
{
    /// <summary>
    /// Factory to resolve the intersection service based on the type of <see cref="IShape"/> 
    /// </summary>
    public interface IIntersectionFactory
    {
        /// <summary>
        /// Gets the appropriate intersection service based on the type of the <see cref="IShape"/>
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>The appropriate intersection service</returns>
        IIntersectionService GetIntersectionService(IShape shape1, IShape shape2);
    }
}
