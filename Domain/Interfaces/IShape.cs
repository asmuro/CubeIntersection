using Domain.Entities.Coordinates;

namespace Domain.Interfaces
{
    /// <summary>
    /// Models a 3D Shape
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Center of the Shape
        /// </summary>
        Coordinate Center { get; }

        /// <summary>
        /// Dimension of the Shape
        /// </summary>
        int Dimension { get; }
    }
}
