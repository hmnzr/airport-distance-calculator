using AirportDistance.Features.DistanceCalculator.Services;
using AirportDistance.Features.DistanceCalculator.Services.Interfaces;
using AirportDistance.Features.DistanceCalculator.UseCases;
using AirportDistance.Features.DistanceCalculator.Validators;
using AirportDistance.Middlewares;
using FluentValidation;

namespace AirportDistance
{
    public static class Dependencies
    {
        public static void AddServiceComponents(this IServiceCollection services)
        {
            services.AddSingleton<ICTeleportClient, CTeleportClient>();
            services.AddSingleton<GreatCircleDistanceCalculator>();

            services.AddSingleton<ExceptionHandlingMiddleware>();

            services.AddScoped<CalculateGreatDistanceUseCase>();

            services.AddValidatorsFromAssemblyContaining(typeof(CalculateDistanceDtoValidator));
        }
    }
}
