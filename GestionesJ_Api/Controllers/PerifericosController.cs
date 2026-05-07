using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;   
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerifericosController : ControllerBase
    {
        private PerifericosApli servicio = new PerifericosApli();

        [HttpGet]
        public List<Perifericos> Get() => servicio.Consultar();

        [HttpPost]
        public Perifericos Post([FromBody] Perifericos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Perifericos Put([FromBody] Perifericos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Perifericos Delete(int id)
        {
            var entidad = new Perifericos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
