using Microsoft.AspNetCore.Mvc;
using TFGBackend.Business;
using TFGBackend.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace TFGBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly ISesionService _sesionService;

        public SesionController(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        [HttpGet]
        public ActionResult<List<SesionSimpleDto>> GetAll()
        {
            var sesiones = _sesionService.GetAll();
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<SesionSimpleDto> Get(int id)
        {
            var sesion = _sesionService.Get(id);
            if (sesion == null)
                return NotFound();

            return Ok(sesion);
        }

        [HttpGet("Pista/{id}")]
        public ActionResult<SesionSimpleDto> GetPista(int id)
        {
            var sesion = _sesionService.GetPista(id);
            if (sesion == null)
                return NotFound();

            return Ok(sesion);
        }

        [HttpPost]
        public IActionResult Create(SesionSimpleDto sesionDTO)
        {
            _sesionService.Add(sesionDTO);
            return CreatedAtAction(nameof(Get), new { id = sesionDTO.IdSesion }, sesionDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SesionUpdateDto sesionUpdateDTO)
        {
            if (id != sesionUpdateDTO.IdSesion)
                return BadRequest();

            var sesionToUpdate = new SesionSimpleDto
            {
                IdSesion = id,
                SesionTime = sesionUpdateDTO.SesionTime,
                SesionDate = sesionUpdateDTO.SesionDate,
                Reservado = sesionUpdateDTO.Reservado,
                IdPista = sesionUpdateDTO.IdPista
            };

            _sesionService.Update(sesionToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sesion = _sesionService.Get(id);
            if (sesion == null)
                return NotFound();

            _sesionService.Delete(id);
            return NoContent();
        }
    }
}
