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

        [HttpGet("Get")]
        public List<Roms> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Roms Post([FromBody] Roms entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Roms Put([FromBody] Roms entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Roms Delete([FromBody] Roms entidad) => servicio.Eliminar(entidad);
    }
}