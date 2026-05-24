using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiGeneralesController : ControllerBase
    {
        private ConfiGeneralesApli servicio = new ConfiGeneralesApli();

        [HttpGet("Get")]
        public List<ConfiGenerales> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public ConfiGenerales Post([FromBody] ConfiGenerales entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public ConfiGenerales Put([FromBody] ConfiGenerales entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public ConfiGenerales Delete([FromBody] ConfiGenerales entidad) => servicio.Eliminar(entidad);
    }
}