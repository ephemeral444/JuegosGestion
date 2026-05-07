using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfiGeneralesController : ControllerBase
    {
        private ConfiGeneralesApli servicio = new ConfiGeneralesApli();

        [HttpGet]
        public List<ConfiGenerales> Get() => servicio.Consultar();

        [HttpPost]
        public ConfiGenerales Post([FromBody] ConfiGenerales entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public ConfiGenerales Put([FromBody] ConfiGenerales entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public ConfiGenerales Delete(int id)
        {
            var entidad = new ConfiGenerales { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
