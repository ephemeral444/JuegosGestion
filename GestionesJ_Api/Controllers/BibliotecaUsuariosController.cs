using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaUsuariosController : ControllerBase
    {
        private BibliotecaUsuariosApli servicio = new BibliotecaUsuariosApli();

        [HttpGet("Get")]
        public List<BibliotecaUsuarios> Get() => servicio.Consultar();

        [HttpPost("Post")]
        public BibliotecaUsuarios Post([FromBody] BibliotecaUsuarios entidad) => servicio.Guardar(entidad);

        [HttpPut("Put")]
        public BibliotecaUsuarios Put([FromBody] BibliotecaUsuarios entidad) => servicio.Modificar(entidad);

        [HttpDelete("Delete")]
        public BibliotecaUsuarios Delete([FromBody] BibliotecaUsuarios entidad) => servicio.Eliminar(entidad);
    }
}