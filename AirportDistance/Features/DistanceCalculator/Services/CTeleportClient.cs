using AirportDistance.Exceptions;
using AirportDistance.Features.DistanceCalculator.Models;

namespace AirportDistance.Features.DistanceCalculator.Services
{
    public class CTeleportClient
    {
        private readonly HttpClient _httpClient;
        private string _baseUri;

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
                throw new EntityNotFoundException("Unable to retrieve airport data.");
            }

            return await response.Content.ReadFromJsonAsync<AirportInfo>();
        }
    }
}
