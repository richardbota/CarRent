using Microsoft.EntityFrameworkCore;

namespace CarRent.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarRent.Models.Vehicles.Vehicle> Vehicle { get; set; }
    }
}
