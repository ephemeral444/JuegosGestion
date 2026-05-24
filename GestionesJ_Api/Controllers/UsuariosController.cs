using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosApli servicio = new UsuariosApli();

        [HttpGet("Get")]
        public List<Usuarios> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Usuarios Post([FromBody] Usuarios entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Usuarios Put([FromBody] Usuarios entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Usuarios Delete([FromBody] Usuarios entidad) => servicio.Eliminar(entidad);
    }
}