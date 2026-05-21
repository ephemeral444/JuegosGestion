using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private PermisosApli servicio = new PermisosApli();

        [HttpGet]
        public List<Permisos> Get() => servicio.Consultar();

        [HttpPost]
        public Permisos Post([FromBody] Permisos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Permisos Put([FromBody] Permisos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Permisos Delete(int id)
        {
            var entidad = new Permisos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
