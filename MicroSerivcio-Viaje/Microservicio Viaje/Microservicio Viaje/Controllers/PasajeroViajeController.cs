using Application.Interfaces.IServices;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Viaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroViajeController : ControllerBase
    {
        private readonly IPasajeroViajeServices _pasajeroViajeService;

        public PasajeroViajeController(IPasajeroViajeServices pasajeroViajeService)
        {
            _pasajeroViajeService = pasajeroViajeService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PasajeroViajeResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequest))]
        public IActionResult GetPasajeroById(int id)
        {
            var result = _pasajeroViajeService.GetPasajeroViajeById(id);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro el pasajero/viaje" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
