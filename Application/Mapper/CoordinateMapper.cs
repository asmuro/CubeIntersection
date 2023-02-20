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
            Coordinate coordinate = new Coordinate();
            coordinate.SetCoordinates(coordinateRequest.X, coordinateRequest.Y, coordinateRequest.Z);
            return coordinate;
        }
    }
}
