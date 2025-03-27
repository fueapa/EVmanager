using EVManager.Domain;
using EVManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVManager.Application
{
    public class PuntoCargaService : IPuntoCargaService
    {
        private readonly AppDbContext _context;

        public PuntoCargaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PuntoCarga>> GetAllAsync()
        {
            return await _context.PuntosCarga.ToListAsync();
        }

        public async Task<PuntoCarga> GetByIdAsync(int id)
        {
            return await _context.PuntosCarga.FindAsync(id);
        }

        public async Task CreateAsync(PuntoCarga puntoCarga)
        {
            _context.PuntosCarga.Add(puntoCarga);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PuntoCarga puntoCarga)
        {
            _context.PuntosCarga.Update(puntoCarga);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var puntoCarga = await _context.PuntosCarga.FindAsync(id);
            if (puntoCarga != null)
            {
                _context.PuntosCarga.Remove(puntoCarga);
                await _context.SaveChangesAsync();
            }
        }
    }
}