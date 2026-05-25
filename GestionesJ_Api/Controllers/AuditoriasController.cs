using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriasController : ControllerBase
    {
        private AuditoriasApli servicio = new AuditoriasApli();

        [HttpGet("Get")]
        public List<Auditorias> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Auditorias Post([FromBody] Auditorias entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Auditorias Put([FromBody] Auditorias entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Auditorias Delete([FromBody] Auditorias entidad) => servicio.Eliminar(entidad);
    }
}