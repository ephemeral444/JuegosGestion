using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private NotificacionesApli servicio = new NotificacionesApli();

        [HttpGet("Get")]
        public List<Notificaciones> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Notificaciones Post([FromBody] Notificaciones entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Notificaciones Put([FromBody] Notificaciones entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Notificaciones Delete([FromBody] Notificaciones entidad) => servicio.Eliminar(entidad);
    }
}