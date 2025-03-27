using Microsoft.AspNetCore.Mvc;
using EVManager.Domain;
using EVManager.Application;
using EVManager.Api.Dtos;

namespace EVManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntosCargaController : ControllerBase
    {
        private readonly IPuntoCargaService _puntoCargaService;

        public PuntosCargaController(IPuntoCargaService puntoCargaService)
        {
            _puntoCargaService = puntoCargaService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PuntoCarga>>> GetAllChargingPoints()
        {
            var puntosCarga = await _puntoCargaService.GetAllAsync();
            return Ok(puntosCarga);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoCarga>> GetChargingPointById(int id)
        {
            var puntoCarga = await _puntoCargaService.GetByIdAsync(id);
            if (puntoCarga == null)
            {
                return NotFound();
            }
            return Ok(puntoCarga);
        }

        [HttpPost("{create}") ]
        public async Task<OperationResultDto> Create([FromBody] CreatePuntoCargaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResultDto(false, "Datos invalidos");
            }

            var puntoCarga = new PuntoCarga
            {
                Ubicacion = dto.Ubicacion,
                EstaDisponible = dto.EstaDisponible,
                Capacidad = dto.Capacidad
            };

            await _puntoCargaService.CreateAsync(puntoCarga);
            return new OperationResultDto(true, "Punto de carga creado correctamente");
        }

        [HttpPut("{update}")]
        public async Task<OperationResultDto> Update(int id, [FromBody] UpdatePuntoCargaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new OperationResultDto(false, "Datos inválidos");
            }

            var existingPuntoCarga = await _puntoCargaService.GetByIdAsync(id);
            if (existingPuntoCarga == null)
            {
                return new OperationResultDto(false, "Punto de carga no encontrado");
            }

            existingPuntoCarga.EstaDisponible = dto.EstaDisponible;
            existingPuntoCarga.Capacidad = dto.Capacidad;

            await _puntoCargaService.UpdateAsync(existingPuntoCarga);
            return new OperationResultDto(true, "Punto de carga actualizado correctamente");
        }

        [HttpDelete("{delete}")]
        public async Task<OperationResultDto> Delete(int id)
        {
            var puntoCarga = await _puntoCargaService.GetByIdAsync(id);
            if (puntoCarga == null)
            {
                return new OperationResultDto(false, "Punto de carga no encontrado");
            }

            await _puntoCargaService.DeleteAsync(id);
            return new OperationResultDto(true, "Punto de carga eliminado correctamente");
        }
    }
}