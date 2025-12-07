namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int FoundedYear { get; set; }
        public ICollection<Car>?Cars { get; set; }
    }
}
