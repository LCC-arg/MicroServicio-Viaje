using Application.Exceptions;
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
        [ProducesResponseType(typeof(Viaje), 201)]
        [ProducesResponseType(typeof(BadRequest),400)]
        public IActionResult CreatePasajero(ViajeRequest request)
        {
            try
            {
                var result = _viajeServices.CreateViaje(request);

                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }

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

        [HttpGet("pasajeros/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PasajeroResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequest))]
        public IActionResult GetAllPasajerosById(int id)
        {
            try
            {
                var result = _viajeServices.GetAllPasajerosById(id);
                if (result == null)
                {
                    return NotFound(new { message = "No se encontraron pasajeros" });
                }

                return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch(InvalidOperationException ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ViajeResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteViaje(int id)
        {
            try
            {
                var result = _viajeServices.DeleteViaje(id);

                return Ok(result);
            }catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch(HasConflictException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public IActionResult GetViajes(string? tipo, DateTime? fechaSalida, DateTime? fechaLlegada)
        {
            var result = _viajeServices.GetViajes(tipo, fechaSalida, fechaLlegada);

            if (result == null)
            {
                return NotFound(new { message = "No se encontraron viajes" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
