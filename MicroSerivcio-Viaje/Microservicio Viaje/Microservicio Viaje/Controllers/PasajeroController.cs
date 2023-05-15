using Application.Interfaces.IServices;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Viaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroController : ControllerBase
    {
        private readonly IPasajeroServices _pasajeroService;

        public PasajeroController(IPasajeroServices pasajeroService)
        {
            _pasajeroService = pasajeroService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pasajero), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePasajero(PasajeroRequest request) 
        {
            try
            {
                var result = _pasajeroService.CreatePasajero(request);
                if (result == null)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }

                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            catch(InvalidOperationException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PasajeroResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequest))]
        public IActionResult GetPasajeroById(int id)
        {
            var result = _pasajeroService.GetPasajeroById(id);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro el pasajero" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> DeleteMercaderia(int id)
        {
            var result = _pasajeroService.DeletePasajero(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public IActionResult UpdatePasajero(int id, PasajeroRequest request)
        {
            var result = _pasajeroService.UpdatePasajero(id, request);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro el pasajero" });
            }
            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public IActionResult GetPasajeros(string nombre, string apellido)
        {
            var result = _pasajeroService.GetPasajeros(nombre, apellido);

            if (result == null)
            {
                return NotFound(new { message = "No se encontraron pasajeros" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

    }
}
