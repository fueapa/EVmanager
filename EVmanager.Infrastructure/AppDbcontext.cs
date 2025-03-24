using Microsoft.EntityFrameworkCore;
using EVManager.Domain;

namespace EVManager.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        

        public DbSet<Vehiculo> Vehiculos { get; set; }    
        public DbSet<PuntoCarga> PuntosCarga { get; set; } 
    }
}