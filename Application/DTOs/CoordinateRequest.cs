
namespace Application.DTOs
{
    /// <summary>
    /// Models a 3D Coordinate
    /// </summary>
    public class CoordinateRequest
    {
        /// <summary>
        /// Constructor with 3D coordinates
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        public CoordinateRequest(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// z coordinate
        /// </summary>
        public int Z { get; set; }
    }
}
