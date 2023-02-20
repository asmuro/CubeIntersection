using System;
using Domain.Entities.Cubes;
using Domain.Interfaces;

namespace Domain.Services
{
    /// <inheritdoc/>
    public class IntersectionFactory: IIntersectionFactory
    {
        /// <inheritdoc/>
        public IIntersectionService GetIntersectionService(IShape shape1, IShape shape2)
        {
            if (shape1 is Cube && shape2 is Cube)
                return new IntersectionCubeService();

            return new IntersectionDummyService();
        }
    }
}
