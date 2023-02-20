
namespace Domain.Entities.Coordinates
{
    public partial class Coordinate
    {
        /// <summary>
        /// Public constructor with x, y and z
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        public Coordinate(int x, int y, int z)
        {
            X= x;
            Y= y;
            Z= z;
        }
    }
}
