using Microsoft.AspNetCore.Mvc;
using EVManager.Domain;
using EVManager.Application;
using EVManager.Api.Dtos;

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

        [HttpPost("{create}")]
        public async Task<OperationResultDto> Create([FromBody] CreateVehiculoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResultDto(false, "Datos inválidos");
            }

            var vehiculo = new Vehiculo
            {
                Placa = dto.Placa,
                Modelo = dto.Modelo,
                NivelBateria = dto.NivelBateria,
                EstaCargando = dto.EstaCargando
            };

            await _vehiculoService.CreateAsync(vehiculo);
            return new OperationResultDto(true, "Vehículo creado correctamente");
        }

        [HttpPut("{update}")]
        public async Task<OperationResultDto> Update(int id, [FromBody] UpdateVehiculoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResultDto(false, "Datos inválidos");
            }

            var existingVehiculo = await _vehiculoService.GetByIdAsync(id);
            if (existingVehiculo == null)
            {
                return new OperationResultDto(false, "Vehículo no encontrado");
            }

            existingVehiculo.NivelBateria = dto.NivelBateria;
            existingVehiculo.EstaCargando = dto.EstaCargando;

            await _vehiculoService.UpdateAsync(existingVehiculo);
            return new OperationResultDto(true, "Vehículo actualizado correctamente");
        }

        [HttpDelete("{delete}")]
        public async Task<OperationResultDto> Delete(int id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return new OperationResultDto(false, "Vehículo no encontrado");
            }

            await _vehiculoService.DeleteAsync(id);
            return new OperationResultDto(true, "Vehículo eliminado correctamente");
        }
    }
}