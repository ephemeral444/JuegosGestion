using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiGraficas : ControllerBase
    {
        private ConfiGraficasApli servicio = new ConfiGraficasApli();

        [HttpGet("Get")]
        public List<GestionJ_biblioteca.Entidades.ConfiGraficas> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public GestionJ_biblioteca.Entidades.ConfiGraficas Post([FromBody] GestionJ_biblioteca.Entidades.ConfiGraficas entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public GestionJ_biblioteca.Entidades.ConfiGraficas Put([FromBody] GestionJ_biblioteca.Entidades.ConfiGraficas entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public GestionJ_biblioteca.Entidades.ConfiGraficas Delete([FromBody] GestionJ_biblioteca.Entidades.ConfiGraficas entidad) => servicio.Eliminar(entidad);
    }
}