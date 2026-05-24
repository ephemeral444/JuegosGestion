using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmuladoresController : ControllerBase
    {
        private EmuladoresApli servicio = new EmuladoresApli();

        [HttpGet("Get")]
        public List<Emuladores> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Emuladores Post([FromBody] Emuladores entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Emuladores Put([FromBody] Emuladores entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Emuladores Delete([FromBody] Emuladores entidad) => servicio.Eliminar(entidad);
    }
}