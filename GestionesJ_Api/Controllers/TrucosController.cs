using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucosController : ControllerBase
    {
        private TrucosApli servicio = new TrucosApli();

        [HttpGet("Get")]
        public List<Trucos> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public Trucos Post([FromBody] Trucos entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public Trucos Put([FromBody] Trucos entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public Trucos Delete([FromBody] Trucos entidad) => servicio.Eliminar(entidad);
    }
}