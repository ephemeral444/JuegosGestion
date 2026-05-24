using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogrosController : ControllerBase
    {
        private LogrosApli servicio = new LogrosApli();

        [HttpGet("Get")]
        public List<Logros> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Logros Post([FromBody] Logros entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Logros Put([FromBody] Logros entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Logros Delete([FromBody] Logros entidad) => servicio.Eliminar(entidad);
    }
}