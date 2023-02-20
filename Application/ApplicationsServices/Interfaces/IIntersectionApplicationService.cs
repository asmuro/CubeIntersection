using Application.DTOs;

namespace Application.ApplicationsServices.Interfaces
{
    /// <summary>
    /// Offers services about intersection of shapes in the application layer
    /// </summary>
    public interface IIntersectionApplicationService
    {
        /// <summary>
        /// Returns if two shapes intersects
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>True if the two shapes intersects or overlaps</returns>
        Task<bool> IntersectsAsync(IShapeRequest shape1, IShapeRequest shape2);

        /// <summary>
        /// Returns the volume of two overlapping shapes
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>The volume of the overlapping</returns>
        Task<double> IntersectionVolumeAsync(IShapeRequest shape1, IShapeRequest shape2);
    }
}
