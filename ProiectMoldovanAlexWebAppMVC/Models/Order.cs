using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProiectMoldovanAlexWebAppMVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int? OwnerID { get; set; }
        public int? CarID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public Owner? Owner { get; set; }
        public Car? Car { get; set; }
    }
}
