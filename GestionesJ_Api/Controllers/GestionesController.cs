using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionesController : ControllerBase
    {
        private GestionesApli servicio = new GestionesApli();

        [HttpGet("Get")]
        public List<Gestiones> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Gestiones Post([FromBody] Gestiones entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Gestiones Put([FromBody] Gestiones entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Gestiones Delete([FromBody] Gestiones entidad) => servicio.Eliminar(entidad);
    }
}