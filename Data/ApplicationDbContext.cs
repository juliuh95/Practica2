using Microsoft.EntityFrameworkCore;
using Practica2.Entidades;

namespace Practica2.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehiclePhoto> VehiclePhoto { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Brand> Brand { get; set; }

  
        
    }
}
