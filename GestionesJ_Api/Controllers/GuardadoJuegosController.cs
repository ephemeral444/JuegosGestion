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

        [HttpGet]
        public List<GuardadoJuegos> Get() => servicio.Consultar();

        [HttpPost]
        public GuardadoJuegos Post([FromBody] GuardadoJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public GuardadoJuegos Put([FromBody] GuardadoJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public GuardadoJuegos Delete(int id)
        {
            var entidad = new GuardadoJuegos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
