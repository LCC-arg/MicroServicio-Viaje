using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio.Viaje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajerosController : ControllerBase
    {
        private readonly IPasajeroService _service;

        public PasajerosController(IPasajeroService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetPasajeroList()
        {
            var result = _service.GetPasajeroList();
            return new JsonResult(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PasajeroResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreatePasajero(PasajeroRequest request)
        {
            try
            {
                var result = _service.CreatePasajero(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetPasajeroById(int id)
        {
            try
            {
                var result = _service.GetPasajeroById(id);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult UpdatePasajero(int id, PasajeroRequest request)
        {
            try
            {
                var result = _service.UpdatePasajero(id, request);
                return new JsonResult(result);
            }

            catch (ArgumentException ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PasajeroResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult RemovePasajero(int id)
        {
            try
            {
                var result = _service.RemovePasajero(id);
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }
    }
}
