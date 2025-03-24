using Microsoft.AspNetCore.Mvc;
using EVManager.Application;
using EVManager.Domain;

namespace EVManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehiculo vehiculo)
        {
            await _vehiculoService.CreateAsync(vehiculo);
            return CreatedAtAction(nameof(GetById), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return BadRequest();
            await _vehiculoService.UpdateAsync(vehiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehiculoService.DeleteAsync(id);
            return NoContent();
        }
    }
}