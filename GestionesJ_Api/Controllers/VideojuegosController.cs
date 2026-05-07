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

        [HttpGet]
        public List<Videojuegos> Get() => servicio.Consultar();

        [HttpPost]
        public Videojuegos Post([FromBody] Videojuegos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Videojuegos Put([FromBody] Videojuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Videojuegos Delete(int id)
        {
            var entidad = new Videojuegos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
