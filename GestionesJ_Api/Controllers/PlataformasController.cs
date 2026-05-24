using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlataformasController : ControllerBase
    {
        private PlataformasApli servicio = new PlataformasApli();

        [HttpGet("Get")]
        public List<Plataformas> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Plataformas Post([FromBody] Plataformas entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Plataformas Put([FromBody] Plataformas entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Plataformas Delete([FromBody] Plataformas entidad) => servicio.Eliminar(entidad);
    }
}