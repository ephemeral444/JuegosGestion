using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DescargasController : ControllerBase
    {
        private DescargasApli servicio = new DescargasApli();

        [HttpGet("Get")]
        public List<Descargas> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Descargas Post([FromBody] Descargas entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Descargas Put([FromBody] Descargas entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Descargas Delete([FromBody] Descargas entidad) => servicio.Eliminar(entidad);
    }
}