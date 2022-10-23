using Microsoft.EntityFrameworkCore;
using Practica2.Entidades;

namespace Practica2.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<VehicleType> VehicleType { get; set; }
    }
}
