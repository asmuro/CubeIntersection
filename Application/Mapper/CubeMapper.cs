using Application.DTOs;
using Domain.Entities.Cubes;

namespace Application.Mapper
{
    /// <summary>
    /// Mapper from CubeRequest to Cube
    /// </summary>
    public static class CubeMapper
    {
        /// <summary>
        /// Map a CubeRequest to a Cube
        /// </summary>
        /// <param name="cubeRequest">CubeRequest to map</param>
        /// <returns>Mapped Cube</returns>
        public static Cube Map(CubeRequest cubeRequest)
        {
            Cube cube = new();
            cube.SetCenter(CoordinateMapper.Map(cubeRequest.Center));
            cube.SetDimension(cubeRequest.Dimension);
            return cube;
        }
    }
}
