
namespace Application.DTOs
{
    /// <summary>
    /// Models a 3D Shape
    /// </summary>
    public interface IShapeRequest
    {
        /// <summary>
        /// Center of the 3D shape
        /// </summary>
        CoordinateRequest Center { get; }

        /// <summary>
        /// Dimension of the 3D shape
        /// </summary>
        int Dimension { get; }
    }
}
