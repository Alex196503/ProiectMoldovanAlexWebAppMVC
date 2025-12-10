namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class CarPricePredictionInput
    { 
        public string Car_Name { get; set; }
        public int Year { get; set; }
        public float Present_Price { get; set; }
        public int Kms_Driven { get; set; }
        public string Full_Type { get; set; }
        public string Seller_Type { get; set; }
        public string Transmission { get; set; }
        public int Owner { get; set; }
    }
}
