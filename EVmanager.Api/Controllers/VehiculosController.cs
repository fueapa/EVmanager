using Microsoft.AspNetCore.Mvc;
using EVManager.Domain;
using EVManager.Application;
using EVManager.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAllVehicles()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehicleById(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Create([FromBody] CreateVehiculoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new OperationResultDto(false, "Datos inválidos"));
            }

            var vehiculo = new Vehiculo
            {
                Placa = dto.Placa,
                Modelo = dto.Modelo,
                NivelBateria = dto.NivelBateria,
                EstaCargando = dto.EstaCargando
            };

            await _vehiculoService.CreateAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResultDto>> Update(int id, [FromBody] UpdateVehiculoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new OperationResultDto(false, "Datos inválidos"));
            }

            var existingVehiculo = await _vehiculoService.GetByIdAsync(id);
            if (existingVehiculo == null)
            {
                return NotFound(new OperationResultDto(false, "Vehículo no encontrado"));
            }

            existingVehiculo.NivelBateria = dto.NivelBateria;
            existingVehiculo.EstaCargando = dto.EstaCargando;

            await _vehiculoService.UpdateAsync(existingVehiculo);
            return Ok(new OperationResultDto(true, "Vehículo actualizado correctamente"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResultDto>> Delete(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound(new OperationResultDto(false, "Vehículo no encontrado"));
            }

            await _vehiculoService.DeleteAsync(id);
            return Ok(new OperationResultDto(true, "Vehículo eliminado correctamente"));
        }
    }
}
