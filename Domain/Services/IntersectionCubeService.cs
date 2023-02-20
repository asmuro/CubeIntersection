using Domain.Entities.Cubes;
using Domain.Interfaces;

namespace Domain.Services
{
    public class IntersectionCubeService : IIntersectionService
    {
        #region IIntersectionService
        
        /// <inheritdoc/>
        public Task<double> IntersectionVolumeAsync(IShape shape1, IShape shape2)
        {
            double widthOverlapping = 0.0;
            double heightOverlapping = 0.0;
            double depthOverlapping = 0.0;
            if (shape1 is Cube cube1 && shape2 is Cube cube2)
            {
                widthOverlapping = CalculateWidthOverlapping(cube1, cube2);
                heightOverlapping = CalculateHeightOverlapping(cube1, cube2);
                depthOverlapping = CalculateDepthOverlapping(cube1, cube2);


                if (HaveSameCentreAndDimension(cube1, cube2))
                    return Task.FromResult<double>(shape1.Dimension * shape1.Dimension * shape1.Dimension);
            }
            return Task.FromResult<double>(widthOverlapping * heightOverlapping * depthOverlapping);
        }

        /// <inheritdoc/>
        public Task<bool> IntersectsAsync(IShape cube1, IShape cube2)
        {
            return Task.FromResult<bool>(Math.Max(Math.Max(Math.Abs(cube1.Center.X - cube2.Center.X), Math.Abs(cube1.Center.Y - cube2.Center.Y)),
                Math.Abs(cube1.Center.Z - cube2.Center.Z)) - (cube1.Dimension / 2 + cube2.Dimension / 2) <= 0);
        }

        #endregion

        #region Intersection Volume

        private bool HaveSameCentreAndDimension(Cube cube1, Cube cube2)
        {
            return (cube1.Center.X == cube2.Center.X
                && cube1.Center.Y == cube2.Center.Y
                && cube1.Center.Z == cube2.Center.Z
                && cube1.Dimension == cube2.Dimension);
        }

        private double CalculateWidthOverlapping(Cube cube1, Cube cube2)
        {
            if (cube2.Center.X > cube1.Center.X)
                return Math.Min(cube1.Xmax - cube2.Xmin, Math.Min(cube1.Dimension, cube2.Dimension));
            else
                return Math.Min(cube2.Xmax - cube1.Xmin, Math.Min(cube1.Dimension, cube2.Dimension));
        }

        private double CalculateHeightOverlapping(Cube cube1, Cube cube2)
        {
            if (cube2.Center.Y > cube1.Center.Y)
                return Math.Min(cube1.Ymax - cube2.Ymin, Math.Min(cube1.Dimension, cube2.Dimension));
            else
                return Math.Min(cube2.Ymax - cube1.Ymin, Math.Min(cube1.Dimension, cube2.Dimension));
        }

        private double CalculateDepthOverlapping(Cube cube1, Cube cube2)
        {
            if (cube2.Center.Z > cube1.Center.Z)
                return Math.Min(cube1.Zmax - cube2.Zmin, Math.Min(cube1.Dimension, cube2.Dimension));
            else
                return Math.Min(cube2.Zmax - cube1.Zmin, Math.Min(cube1.Dimension, cube2.Dimension));
        }

        #endregion
    }
}
