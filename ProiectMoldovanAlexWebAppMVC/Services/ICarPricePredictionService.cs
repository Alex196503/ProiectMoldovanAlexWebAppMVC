using ProiectMoldovanAlexWebAppMVC.Models;

namespace ProiectMoldovanAlexWebAppMVC.Services
{
    public interface ICarPricePredictionService
    {
        Task<float> SellPriceAsync(CarPricePredictionInput input);
    }
}
