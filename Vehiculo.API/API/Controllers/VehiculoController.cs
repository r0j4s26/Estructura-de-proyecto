using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private readonly IVehiculoFlujo _vehiculoFlujo;
        private readonly ILogger<VehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoFlujo, ILogger<VehiculoController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _vehiculoFlujo.Agregar(vehiculo);
                return CreatedAtAction(nameof(Obtener), new { Id = resultado }, vehiculo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar vehículo");
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar(Guid Id, [FromBody] VehiculoRequest vehiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _vehiculoFlujo.Editar(Id, vehiculo);
                return Ok(new { mensaje = "Vehículo actualizado", id = resultado });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al editar vehículo {Id}");
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar(Guid Id)
        {
            try
            {
                await _vehiculoFlujo.Eliminar(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar vehículo {Id}");
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _vehiculoFlujo.Obtener();
            if (resultado == null || !resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener(Guid Id)
        {
            try
            {
                var resultado = await _vehiculoFlujo.Obtener(Id);
                if (resultado == null) return NotFound();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener vehículo {Id}");
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}