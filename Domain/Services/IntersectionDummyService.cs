using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Services
{
    /// <summary>
    /// Intersection dummy service in case we don't have the implementation of the specific shape
    /// </summary>
    internal class IntersectionDummyService : IIntersectionService
    {
        #region IIntersectionService

        /// <inheritdoc/>
        public Task<double> IntersectionVolumeAsync(IShape shape1, IShape shape2)
        {
            return Task.FromResult<double>(0);
        }
        /// <inheritdoc/>
        public Task<bool> IntersectsAsync(IShape shape1, IShape shape2)
        {
            return Task.FromResult<bool>(false);
        }

        #endregion
    }
}
