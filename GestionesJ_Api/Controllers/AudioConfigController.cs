using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioConfigController : ControllerBase
    {
        private ConfigAudiosApli servicio = new ConfigAudiosApli();

        [HttpGet("Get")]
        public List<ConfigAudios> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public ConfigAudios Post([FromBody] ConfigAudios entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public ConfigAudios Put([FromBody] ConfigAudios entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public ConfigAudios Delete([FromBody] ConfigAudios entidad) => servicio.Eliminar(entidad);
    }
}