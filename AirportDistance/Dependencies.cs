using AirportDistance.Features.DistanceCalculator.Services;
using AirportDistance.Features.DistanceCalculator.UseCases;

namespace AirportDistance
{
    public static class Dependencies
    {
        public static void AddServiceComponents(this IServiceCollection services)
        {
            services.AddSingleton<CTeleportClient>();
            services.AddSingleton<GreatCircleDistanceCalculator>();
            services.AddScoped<CalculateGreatDistanceUseCase>();
        }
    }
}
