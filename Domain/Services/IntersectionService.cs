using Domain.DependencyInjection;
using Domain.Interfaces;

namespace Domain.Services
{
    public class IntersectionService : IIntersectionService
    {
        /// <inheritdoc/>
        public async Task<bool> IntersectsAsync(IShape shape1, IShape shape2)
        {
            IIntersectionFactory intersectionFactory = ContainerConfigurationModule.Resolve<IIntersectionFactory>();
            return await intersectionFactory.GetIntersectionService(shape1, shape2).IntersectsAsync(shape1, shape2);
        }

        /// <inheritdoc/>
        public async Task<double> IntersectionVolumeAsync(IShape shape1, IShape shape2)
        {
            IIntersectionFactory intersectionFactory = ContainerConfigurationModule.Resolve<IIntersectionFactory>();
            return await intersectionFactory.GetIntersectionService(shape1, shape2).IntersectionVolumeAsync(shape1, shape2);
        }
    }
}
