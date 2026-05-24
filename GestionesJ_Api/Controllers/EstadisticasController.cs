using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadisticasController : ControllerBase
    {
        private EstadisticasApli servicio = new EstadisticasApli();

        [HttpGet("Get")]
        public List<Estadisticas> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Estadisticas Post([FromBody] Estadisticas entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Estadisticas Put([FromBody] Estadisticas entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Estadisticas Delete([FromBody] Estadisticas entidad) => servicio.Eliminar(entidad);
    }
}
