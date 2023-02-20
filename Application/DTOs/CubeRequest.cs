
namespace Application.DTOs
{
    /// <summary>
    /// Models a Cube
    /// </summary>
    public class CubeRequest : IShapeRequest
    {
        /// <inheritdoc/>
        public CoordinateRequest? Center {get; set;}

        /// <inheritdoc/>
        public int Dimension { get; set; }
    }
}
