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

        [HttpGet("Get")]
        public List<Perifericos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Perifericos Post([FromBody] Perifericos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Perifericos Put([FromBody] Perifericos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Perifericos Delete([FromBody] Perifericos entidad) => servicio.Eliminar(entidad);
    }
}