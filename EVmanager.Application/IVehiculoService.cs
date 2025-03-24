using EVManager.Domain;

namespace EVManager.Application
{
    public interface IVehiculoService
    {
        Task<List<Vehiculo>> GetAllAsync();      
        Task<Vehiculo> GetByIdAsync(int id);     
        Task CreateAsync(Vehiculo vehiculo);    
        Task UpdateAsync(Vehiculo vehiculo);     
        Task DeleteAsync(int id);                
    }
}