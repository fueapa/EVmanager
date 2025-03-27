using EVManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVManager.Application
{
    public interface IPuntoCargaService
    {
        Task<IEnumerable<PuntoCarga>> GetAllAsync();
        Task<PuntoCarga> GetByIdAsync(int id);
        Task CreateAsync(PuntoCarga puntoCarga);
        Task UpdateAsync(PuntoCarga puntoCarga);
        Task DeleteAsync(int id);
    }
}