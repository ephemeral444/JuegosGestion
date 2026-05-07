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

        [HttpGet]
        public List<BibliotecaUsuarios> Get() => servicio.Consultar();

        [HttpPost]
        public BibliotecaUsuarios Post([FromBody] BibliotecaUsuarios entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public BibliotecaUsuarios Put([FromBody] BibliotecaUsuarios entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public BibliotecaUsuarios Delete(int id)
        {
            var entidad = new BibliotecaUsuarios { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
