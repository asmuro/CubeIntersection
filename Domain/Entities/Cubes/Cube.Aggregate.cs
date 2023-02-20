using Domain.Entities.Coordinates;

namespace Domain.Entities.Cubes
{
    public partial class Cube
    {
        public double CenterToFaceDistance => (double)Dimension / 2;

        public double Xmax => Center.X + CenterToFaceDistance;

        public double Xmin => Center.X - CenterToFaceDistance;

        public double Ymax => Center.Y + CenterToFaceDistance;

        public double Ymin => Center.Y - CenterToFaceDistance;

        public double Zmax => Center.Z + CenterToFaceDistance;

        public double Zmin => Center.Z - CenterToFaceDistance;

        public void SetCenter(Coordinate center)
        {
            Center = center;
        }

        public void SetDimension(int dimension)
        {
            Dimension = dimension;
        }
    }
}
