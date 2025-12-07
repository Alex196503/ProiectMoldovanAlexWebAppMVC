using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class Engine
    {
        public int EngineID { get; set; }
        public string Type { get; set; }
        public int HorsePower { get; set; }
        public int Cylinders { get; set; }
        public double Displacement { get; set; }
        public ICollection<Car>?Cars { get; set; }
    }
}
