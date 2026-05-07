using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogrosController : ControllerBase
    {
        private LogrosApli servicio = new LogrosApli();

        [HttpGet]
        public List<Logros> Get() => servicio.Consultar();

        [HttpPost]
        public Logros Post([FromBody] Logros entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Logros Put([FromBody] Logros entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Logros Delete(int id)
        {
            var entidad = new Logros { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
