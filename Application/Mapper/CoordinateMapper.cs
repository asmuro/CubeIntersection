using Application.DTOs;
using Domain.Entities.Coordinates;

namespace Application.Mapper
{
    /// <summary>
    /// Mapper from CoordinateRequest to Coordinate
    /// </summary>
    public static class CoordinateMapper
    {
        /// <summary>
        /// Maps a CoordinateRequest to a Coordinate
        /// </summary>
        /// <param name="coordinateRequest">Coordinate to map</param>
        /// <returns>Coordinate mapped</returns>
        public static Coordinate Map(CoordinateRequest coordinateRequest)
        {
            return new Coordinate(coordinateRequest.X, coordinateRequest.Y, coordinateRequest.Z);
        }
    }
}
