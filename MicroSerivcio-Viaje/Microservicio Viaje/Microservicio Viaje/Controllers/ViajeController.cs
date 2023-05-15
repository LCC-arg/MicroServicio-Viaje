using Application.Interfaces.IServices;
using Application.Request;
using Application.Response;
using Application.UseCase;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio_Viaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeServices _viajeServices;

        public ViajeController(IViajeServices viajeServices)
        {
            _viajeServices = viajeServices;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Viaje), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatePasajero(ViajeRequest request)
        {
            var result = _viajeServices.CreateViaje(request);
            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViajeResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequest))]
        public IActionResult GetViajeById(int id)
        {
            var result = _viajeServices.GetViajeById(id);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro el viaje" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ViajeResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteViaje(int id)
        {
            var result = _viajeServices.DeleteViaje(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ViajeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status404NotFound)]
        public IActionResult UpdatePasajero(int id, ViajeRequest request)
        {
            var result = _viajeServices.UpdateViaje(id, request);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro el viaje" });
            }
            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
