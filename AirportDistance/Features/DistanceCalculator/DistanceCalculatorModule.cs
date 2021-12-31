using AirportDistance.Features.DistanceCalculator.Dtos;
using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.UseCases;
using Carter;

namespace AirportDistance.Features.DistanceCalculator
{
    public class DistanceCalculatorModule: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/distance", CalculateGreatDistance)
                .Produces<DistanceInfo>()
                .WithTags("Distance")
                .WithDisplayName("Calculates great circle distance between two airports based on their IATA code.");
        }

        private async Task<IResult> CalculateGreatDistance(
            string? from,
            string? to,
            CalculateGreatDistanceUseCase useCase)
        {
            var dto = new CalculateDistanceDto(from, to);
            var distance = await useCase
                .WithParameters(dto)
                .Execute();

            return Results.Ok(distance);
        }
    }
}
