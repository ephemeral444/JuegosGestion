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

        [HttpGet]
        public List<Emuladores> Get() => servicio.Consultar();

        [HttpPost]
        public Emuladores Post([FromBody] Emuladores entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Emuladores Put([FromBody] Emuladores entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Emuladores Delete(int id)
        {
            var entidad = new Emuladores { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
