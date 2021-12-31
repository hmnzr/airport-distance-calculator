using AirportDistance.Exceptions;
using AirportDistance.Features.DistanceCalculator.Dtos;
using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.Services;
using AirportDistance.Features.DistanceCalculator.Services.Interfaces;
using AirportDistance.Features.DistanceCalculator.Validators;
using Carter.ModelBinding;

namespace AirportDistance.Features.DistanceCalculator.UseCases
{
    public class CalculateGreatDistanceUseCase
    {
        private readonly ICTeleportClient _cTeleportClient;
        private readonly GreatCircleDistanceCalculator _calculator;
        private readonly CalculateDistanceDtoValidator _calculateDistanceDtoValidator;

        private CalculateDistanceDto _dto;

        public CalculateGreatDistanceUseCase(
            ICTeleportClient client,
            GreatCircleDistanceCalculator calculator,
            CalculateDistanceDtoValidator calculateDistanceDtoValidator)
        {
            _cTeleportClient = client;
            _calculator = calculator;
            _calculateDistanceDtoValidator = calculateDistanceDtoValidator;
        }

        public CalculateGreatDistanceUseCase WithParameters(CalculateDistanceDto dto)
        {
            _dto = dto;

            return this;
        }

        public async Task<DistanceInfo> Execute()
        {
            var validationResult = await _calculateDistanceDtoValidator.ValidateAsync(_dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.GetFormattedErrors());
            }

            var (from, to) = _dto;

            var fromAirport = await _cTeleportClient.GetAirportInfoAsync(from);
            var toAirport = await _cTeleportClient.GetAirportInfoAsync(to);

            var distance = _calculator.CalculateGreatCircleDistance(fromAirport.Location, toAirport.Location, DistanceUnit.Mile);

            return distance;
        }
    }
}
