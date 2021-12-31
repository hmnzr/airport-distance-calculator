using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.Services;

namespace AirportDistance.Features.DistanceCalculator.UseCases
{
    public class CalculateGreatDistanceUseCase
    {
        private readonly CTeleportClient _cTeleportClient;
        private readonly GreatCircleDistanceCalculator _calculator;
        private string _fromIata;
        private string _toIata;

        public CalculateGreatDistanceUseCase(CTeleportClient client, GreatCircleDistanceCalculator calculator)
        {
            _cTeleportClient = client;
            _calculator = calculator;
        }

        public CalculateGreatDistanceUseCase WithParameters(string fromIata, string toIata)
        {
            _fromIata = fromIata;
            _toIata = toIata;

            return this;
        }

        public async Task<DistanceInfo> Execute()
        {
            var fromAirport = await _cTeleportClient.GetAirportInfoAsync(_fromIata);
            var toAirport = await _cTeleportClient.GetAirportInfoAsync(_toIata);

            var distance = _calculator.CalculateGreatCircleDistance(fromAirport.Location, toAirport.Location, DistanceUnit.Mile);

            return distance;
        }
    }
}
