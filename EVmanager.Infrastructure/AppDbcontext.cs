using EVManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace EVManager.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<PuntoCarga> PuntosCarga { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}