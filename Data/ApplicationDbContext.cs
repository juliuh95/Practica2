using Microsoft.EntityFrameworkCore;

namespace Practica2.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
