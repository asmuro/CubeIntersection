using Application.ApplicationsServices.Interfaces;
using Application.DependencyInjection;
using Application.DTOs;
using Application.Mapper;
using Domain.Interfaces;
using IShapeRequest = Application.DTOs.IShapeRequest;

namespace Application.ApplicationsServices
{
    /// <inheritdoc/>
    public class IntersectionApplicationService : IIntersectionApplicationService
    {
        private readonly IIntersectionService _intersectionService;

        /// <summary>
        /// Public constructor
        /// </summary>
        public IntersectionApplicationService()
        {
            _intersectionService = ContainerConfigurationModule.Resolve<IIntersectionService>();
        }

        #region IIntersectionApplicationService

        /// <inheritdoc/>
        public async Task<bool> IntersectsAsync(IShapeRequest shape1, IShapeRequest shape2)
        {
            if (shape1 is CubeRequest cubeRequest1 && shape2 is CubeRequest cubeRequest2)
                return await _intersectionService.IntersectsAsync(CubeMapper.Map(cubeRequest1), 
                    CubeMapper.Map(cubeRequest2));
            
            return false;
        }

        /// <inheritdoc/>
        public async Task<double> IntersectionVolumeAsync(IShapeRequest shape1, IShapeRequest shape2)
        {
            if (shape1 is CubeRequest cubeRequest1 && shape2 is CubeRequest cubeRequest2)
                return await _intersectionService.IntersectionVolumeAsync(
                    CubeMapper.Map(cubeRequest1), CubeMapper.Map(cubeRequest2));
            
            return 0;
        }

        #endregion
    }
}
