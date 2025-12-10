using Microsoft.AspNetCore.Mvc;
using ProiectMoldovanAlexWebAppMVC.Models;
using ProiectMoldovanAlexWebAppMVC.Services;

namespace ProiectMoldovanAlexWebAppMVC.Controllers
{
    public class PricePredictionController : Controller
    {
        private readonly ICarPricePredictionService _servicePrice;
        public PricePredictionController(ICarPricePredictionService servicePrice)
        {
            _servicePrice = servicePrice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CarPricePredictionInputViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult> Index(CarPricePredictionInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var input = new CarPricePredictionInput
            {
                Car_Name = model.Car_Name,
                Year = model.Year,
                Present_Price = model.Present_Price,
                Kms_Driven = model.Kms_Driven,
                Full_Type = model.Full_Type,
                Seller_Type = model.Seller_Type,
                Transmission = model.Transmission,
                Owner = model.Owner
            };
            var prediction = await _servicePrice.SellPriceAsync(input);
            model.Selling_Price = prediction;
            return View(model);
        }
    }

}
