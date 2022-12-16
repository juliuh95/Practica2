using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practica3.Entidades;
using Practica3.Models;

namespace Practica3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<IdentityModels> Fields { get; set; }



    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }*/


}
