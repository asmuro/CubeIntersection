
namespace Domain.Entities.Cubes
{
    public partial class Cube
    {
        internal double CenterToFaceDistance => (double)Dimension / 2;

        internal double Xmax => Center.X + CenterToFaceDistance;

        internal double Xmin => Center.X - CenterToFaceDistance;

        internal double Ymax => Center.Y + CenterToFaceDistance;

        internal double Ymin => Center.Y - CenterToFaceDistance;

        internal double Zmax => Center.Z + CenterToFaceDistance;

        internal double Zmin => Center.Z - CenterToFaceDistance;
    }
}
