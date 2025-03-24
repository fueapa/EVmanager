using Microsoft.EntityFrameworkCore;
using EVManager.Domain;
using EVManager.Infrastructure;

namespace EVManager.Application
{
    public class VehiculoService : IVehiculoService
    {
        private readonly AppDbContext _context; 

        public VehiculoService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<List<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos.ToListAsync(); 
        }

        public async Task<Vehiculo> GetByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id); 
        }

        public async Task CreateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);      
            await _context.SaveChangesAsync();      
        }

        public async Task UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);    
            await _context.SaveChangesAsync();      
        }

        public async Task DeleteAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id); 
            if (vehiculo != null)                    
            {
                _context.Vehiculos.Remove(vehiculo); 
                await _context.SaveChangesAsync();   
            }
        }
    }
}