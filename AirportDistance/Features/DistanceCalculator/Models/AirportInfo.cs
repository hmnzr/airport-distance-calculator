using System.Text.Json.Serialization;

namespace AirportDistance.Features.DistanceCalculator.Models
{
    public record AirportInfo
        (
            string Country,
            [property:JsonPropertyName("city_iata")]
            string CityIata,
            string Iata,
            string City,
            Coordinates Location
        );
}
