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

        [HttpGet]
        public List<Notificaciones> Get() => servicio.Consultar();

        [HttpPost]
        public Notificaciones Post([FromBody] Notificaciones entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Notificaciones Put([FromBody] Notificaciones entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Notificaciones Delete(int id)
        {
            var entidad = new Notificaciones { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
