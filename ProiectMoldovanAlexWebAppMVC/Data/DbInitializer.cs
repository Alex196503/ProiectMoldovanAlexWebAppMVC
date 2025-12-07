using Microsoft.EntityFrameworkCore;
using ProiectMoldovanAlexWebAppMVC.Models;
namespace ProiectMoldovanAlexWebAppMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvier)
        {
            using (var context = new ProiectMoldovanAlexWebAppMVCContext(serviceProvier.GetRequiredService<DbContextOptions<ProiectMoldovanAlexWebAppMVCContext>>()))
            {
                if (context.Car.Any())
                {
                    return;
                }
                context.Car.AddRange(
     new Car { Name = "BestCar", Price = 2000, YearFabrication = 2009, Seats = 10, Color="Red" },
     new Car { Name = "SlowCar", Price = 4000, YearFabrication = 2003, Seats = 8, Color="Dark" },
     new Car { Name = "MostRecentOne", Price = 1500, YearFabrication = 2010, Seats=4, Color="Green"}
 );
                context.Brand.AddRange(
                    new Brand { Name = "BMW", Country = "Germany", FoundedYear = 1916 },
                    new Brand { Name = "Audi", Country = "Germany", FoundedYear = 1909 },
                    new Brand { Name = "Toyota", Country = "Japan", FoundedYear = 1937}   
                    );
                context.Owner.AddRange(
                    new Owner { Name = "Dragos", Adress = "Cluj, Strada Unirii", DrivingConduct = "Aggressive", NumberOfAccidents = 1 },
                    new Owner { Name = "Flavia", Adress = "Dambovita, Cartierul CFR", DrivingConduct = "Prudent", NumberOfAccidents = 0 });
                    

                context.SaveChanges();
            }
        }
    }
}