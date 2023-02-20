using Domain.Entities.Coordinates;

namespace Domain.Interfaces
{
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
