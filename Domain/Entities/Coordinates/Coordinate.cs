
namespace Domain.Entities.Coordinates
{
    /// <summary>
    /// Represent a 3D coordinate
    /// </summary>
    public partial class Coordinate
    {
        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// z coordinate
        /// </summary>
        public int Z { get; private set; }

        /// <summary>
        /// Sets the x, y and z coordinates
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        public void SetCoordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
