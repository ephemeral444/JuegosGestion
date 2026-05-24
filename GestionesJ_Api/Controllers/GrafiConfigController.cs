using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrafiConfigController : ControllerBase
    {
        private ConfiGraficasApli servicio = new ConfiGraficasApli();

        [HttpGet("Get")]
        public List<ConfiGraficas> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public ConfiGraficas Post([FromBody] ConfiGraficas entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public ConfiGraficas Put([FromBody] ConfiGraficas entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public ConfiGraficas Delete([FromBody] ConfiGraficas entidad) => servicio.Eliminar(entidad);
    }
}