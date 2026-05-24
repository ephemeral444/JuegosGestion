using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private PermisosApli servicio = new PermisosApli();

        [HttpGet("Get")]
        public List<Permisos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Permisos Post([FromBody] Permisos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Permisos Put([FromBody] Permisos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Permisos Delete([FromBody] Permisos entidad) => servicio.Eliminar(entidad);
    }
}