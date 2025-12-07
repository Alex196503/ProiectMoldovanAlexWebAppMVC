using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string DrivingConduct { get; set; }
        public int NumberOfAccidents { get; set; }
        
        public ICollection<Order>?Orders { get; set; }
    }
}
