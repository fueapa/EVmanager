using EVManager.Domain;

namespace EVManager.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Vehiculo> Vehiculos { get; }
        IRepository<PuntoCarga> PuntosCarga { get; }
        Task<int> SaveChangesAsync();
    }
}