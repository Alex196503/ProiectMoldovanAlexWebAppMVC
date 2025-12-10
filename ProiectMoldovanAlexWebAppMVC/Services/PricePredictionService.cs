using ProiectMoldovanAlexWebAppMVC.Models;
namespace ProiectMoldovanAlexWebAppMVC.Services
{
    public class PricePredictionService : ICarPricePredictionService
    {
        private readonly HttpClient _httpClient;
        public PricePredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<float> SellPriceAsync(CarPricePredictionInput input)
        {
            var response = await _httpClient.PostAsJsonAsync("/predict", input);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<CarPriceApiResponse>();
            return(float) result?.Price;
        }
        private class CarPriceApiResponse
        {
            public float Price { get; set; }
        }
    }
}
