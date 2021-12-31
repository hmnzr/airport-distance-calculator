using AirportDistance.Features.DistanceCalculator.Models;

namespace AirportDistance.Features.DistanceCalculator.Services.Interfaces;

public interface ICTeleportClient
{
    Task<AirportInfo> GetAirportInfoAsync(string iata);
}