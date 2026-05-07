using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RomsController : ControllerBase
    {
        private RomsApli servicio = new RomsApli();

        [HttpGet]
        public List<Roms> Get() => servicio.Consultar();

        [HttpPost]
        public Roms Post([FromBody] Roms entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Roms Put([FromBody] Roms entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Roms Delete(int id)
        {
            var entidad = new Roms { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
