using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideojuegosController : ControllerBase
    {
        private VideojuegosApli servicio = new VideojuegosApli();

        [HttpGet("Get")]
        public List<Videojuegos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Videojuegos Post([FromBody] Videojuegos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Videojuegos Put([FromBody] Videojuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Videojuegos Delete([FromBody] Videojuegos entidad) => servicio.Eliminar(entidad);
    }
}