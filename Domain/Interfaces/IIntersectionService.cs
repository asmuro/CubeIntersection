
namespace Domain.Interfaces
{
    /// <summary>
    /// Service that exposes intersection operations
    /// </summary>
    public interface IIntersectionService
    {
        /// <summary>
        /// Evaluate if two <see cref="IShape"/> intersects and returns the result
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>True if the shapes intersects or overlaps</returns>
        Task<bool> IntersectsAsync(IShape shape1, IShape shape2);

        /// <summary>
        /// Calculate the intersection volume of two <see cref="IShape"/>
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>The volume of the intersection</returns>
        Task<double> IntersectionVolumeAsync(IShape shape1, IShape shape2);
    }
}
