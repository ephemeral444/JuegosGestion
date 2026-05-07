using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosApli servicio = new UsuariosApli();

        [HttpGet]
        public List<Usuarios> Get() => servicio.Consultar();

        [HttpPost]
        public Usuarios Post([FromBody] Usuarios entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Usuarios Put([FromBody] Usuarios entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Usuarios Delete(int id)
        {
            var entidad = new Usuarios { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
