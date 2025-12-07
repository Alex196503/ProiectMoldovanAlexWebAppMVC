using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class Car
    {
        public int ID { get; set;}
        public int? EngineID { get; set; }
        public int? BrandID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int YearFabrication { get; set; }
        public Engine? Engine { get; set;}
        public Brand? Brand { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
        public ICollection <Order> ? Orders { get; set; }
    }
}
