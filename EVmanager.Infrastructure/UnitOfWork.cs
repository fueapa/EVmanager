using EVManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace EVManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepository<Vehiculo> _vehiculos;
        private IRepository<PuntoCarga> _puntosCarga;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Vehiculo> Vehiculos => _vehiculos ??= new Repository<Vehiculo>(_context);
        public IRepository<PuntoCarga> PuntosCarga => _puntosCarga ??= new Repository<PuntoCarga>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}