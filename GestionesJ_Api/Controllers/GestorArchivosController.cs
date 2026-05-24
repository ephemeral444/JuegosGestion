using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorArchivosController : ControllerBase
    {
        private GestorArchivosApli servicio = new GestorArchivosApli();

        [HttpGet("Get")]
        public List<GestorArchivos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public GestorArchivos Post([FromBody] GestorArchivos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public GestorArchivos Put([FromBody] GestorArchivos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public GestorArchivos Delete([FromBody] GestorArchivos entidad) => servicio.Eliminar(entidad);
    }
}