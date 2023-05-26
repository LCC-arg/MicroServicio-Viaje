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
                ViajeResponse result = _viajeServices.CreateViaje(request);

                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetViajeById(int id)
        {
            try
            {
                if (!int.TryParse(id.ToString(), out _))
                {
                    throw new BadRequestException("El formato de id ingresado es invalido");
                }

                var result = _viajeServices.GetViajeById(id);

                return Ok(result);
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch(NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }
        }

        [HttpGet("pasajeros/{id}")]
        [ProducesResponseType(typeof(IEnumerable<GetAllPasajerosByIdResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetAllPasajerosById(int id)
        {
            try
            {
                var result = _viajeServices.GetAllPasajerosById(id);

                return Ok(result);
            }
            catch(BadRequestException ex) 
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch(NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
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
        [ProducesResponseType(typeof(IEnumerable<ViajeResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetViajes(string? tipo, DateTime? fechaSalida, DateTime? fechaLlegada)
        {
            try
            {
                var result = _viajeServices.GetViajes(tipo, fechaSalida, fechaLlegada);


                return Ok(result);
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }

        }
    }
}
