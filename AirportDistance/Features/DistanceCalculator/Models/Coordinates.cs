using System.Text.Json.Serialization;

namespace AirportDistance.Features.DistanceCalculator.Models
{
    public record Coordinates(
        [property:JsonPropertyName("lat")]
        double Latitude,
        [property:JsonPropertyName("lon")]
        double Longitude);
}
