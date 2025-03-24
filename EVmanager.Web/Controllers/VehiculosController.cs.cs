using Microsoft.AspNetCore.Mvc;
using EVManager.Application;
using EVManager.Domain;

namespace EVManager.Web.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService; 
        }

     
        public async Task<IActionResult> Index()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            return View(vehiculos);
        }

      
        public IActionResult Create()
        {
            return View(); 
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid) 
            {
                await _vehiculoService.CreateAsync(vehiculo);
                return RedirectToAction(nameof(Index)); 
            }
            return View(vehiculo); 
        }

      
        public async Task<IActionResult> Edit(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null) return NotFound(); 
            return View(vehiculo); 
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                await _vehiculoService.UpdateAsync(vehiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vehiculoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}