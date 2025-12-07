using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMoldovanAlexWebAppMVC.Models;

namespace ProiectMoldovanAlexWebAppMVC.Data
{
    public class ProiectMoldovanAlexWebAppMVCContext : DbContext
    {
        public ProiectMoldovanAlexWebAppMVCContext (DbContextOptions<ProiectMoldovanAlexWebAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMoldovanAlexWebAppMVC.Models.Car> Car { get; set; } = default!;
        public DbSet<ProiectMoldovanAlexWebAppMVC.Models.Brand> Brand { get; set; } = default!;
        public DbSet<ProiectMoldovanAlexWebAppMVC.Models.Owner> Owner { get; set; } = default!;
        public DbSet<ProiectMoldovanAlexWebAppMVC.Models.Engine> Engine { get; set; } = default!;
        public DbSet<ProiectMoldovanAlexWebAppMVC.Models.Order> Order { get; set; } = default!;

    }
}
