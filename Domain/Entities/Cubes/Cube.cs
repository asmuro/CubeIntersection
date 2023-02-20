using Domain.Entities.Coordinates;
using Domain.Interfaces;

namespace Domain.Entities.Cubes
{
    /// <summary>
    /// Models a 3D Cube
    /// </summary>
    public partial class Cube: IShape
    {
        public Cube()
        {
            Center = new Coordinate();
        }

        #region IShape

        /// <inheritdoc/>
        public Coordinate Center { get; private set; }
        
        /// <inheritdoc/>
        public int Dimension { get; private set; }

        #endregion

        #region public methods

        /// <summary>
        /// Sets the center of the Cube
        /// </summary>
        /// <param name="center">Center of the cube</param>
        public void SetCenter(Coordinate center)
        {
            Center = center;
        }

        /// <summary>
        /// Sets the size of the cube's edge 
        /// </summary>
        /// <param name="dimension">Size of the cube's edge</param>
        public void SetDimension(int dimension)
        {
            Dimension = dimension;
        }

        #endregion
    }
}
