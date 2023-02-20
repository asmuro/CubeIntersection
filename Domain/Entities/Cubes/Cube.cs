using Domain.Entities.Coordinates;
using Domain.Interfaces;

namespace Domain.Entities.Cubes
{
    public partial class Cube: IShape
    {
        /// <inheritdoc/>
        public Coordinate Center { get; private set; }
        
        /// <inheritdoc/>
        public int Dimension { get; private set; }
    }
}
