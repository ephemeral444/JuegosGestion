using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuardadoJuegosController : ControllerBase
    {
        private GuardadoJuegosApli servicio = new GuardadoJuegosApli();

        [HttpGet("Get")]
        public List<GuardadoJuegos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public GuardadoJuegos Post([FromBody] GuardadoJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public GuardadoJuegos Put([FromBody] GuardadoJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public GuardadoJuegos Delete([FromBody] GuardadoJuegos entidad) => servicio.Eliminar(entidad);
    }
}