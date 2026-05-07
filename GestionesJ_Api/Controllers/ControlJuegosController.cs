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

        [HttpGet]
        public List<ControlJuegos> Get() => servicio.Consultar();

        [HttpPost]
        public ControlJuegos Post([FromBody] ControlJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public ControlJuegos Put([FromBody] ControlJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public ControlJuegos Delete(int id)
        {
            var entidad = new ControlJuegos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
