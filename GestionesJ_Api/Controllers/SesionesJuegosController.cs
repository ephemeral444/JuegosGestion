using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionesJuegosController : ControllerBase
    {
        private SesionesJuegosApli servicio = new SesionesJuegosApli();

        [HttpGet("Get")]
        public List<SesionesJuegos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public SesionesJuegos Post([FromBody] SesionesJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public SesionesJuegos Put([FromBody] SesionesJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public SesionesJuegos Delete([FromBody] SesionesJuegos entidad) => servicio.Eliminar(entidad);
    }
}