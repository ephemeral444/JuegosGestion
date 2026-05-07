using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioConfigController : ControllerBase
    {
        private ConfigAudioApli servicio = new ConfigAudioApli();

        [HttpGet]
        public List<ConfigAudios> Get() => servicio.Consultar();

        [HttpPost]
        public ConfigAudios Post([FromBody] ConfigAudios entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public ConfigAudios Put([FromBody] ConfigAudios entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public ConfigAudios Delete(int id)
        {
            var entidad = new ConfigAudios { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
