using AirportDistance.Exceptions;
using AirportDistance.Features.DistanceCalculator.Models;
using AirportDistance.Features.DistanceCalculator.Services.Interfaces;

namespace AirportDistance.Features.DistanceCalculator.Services
{
    public class CTeleportClient : ICTeleportClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;

        public CTeleportClient(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClient = httpClientFactory.CreateClient();
            _baseUri = config.GetValue<string>("CTeleportBaseUri");
        }

        public async Task<AirportInfo> GetAirportInfoAsync(string iata)
        {
            var url = $"{_baseUri}/airports/{iata.ToUpper()}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response.Content == null)
            {
                throw new EntityNotFoundException($"Unable to retrieve airport data for {iata}.");
            }

            return await response.Content.ReadFromJsonAsync<AirportInfo>();
        }
    }
}
