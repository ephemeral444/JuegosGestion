using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlJuegosController : ControllerBase
    {
        private ControlJuegosApli servicio = new ControlJuegosApli();

        [HttpGet("Get")]
        public List<ControlJuegos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public ControlJuegos Post([FromBody] ControlJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public ControlJuegos Put([FromBody] ControlJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public ControlJuegos Delete([FromBody] ControlJuegos entidad) => servicio.Eliminar(entidad);
    }
}