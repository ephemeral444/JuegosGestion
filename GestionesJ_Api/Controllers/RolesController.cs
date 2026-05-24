using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private RolesApli servicio = new RolesApli();

        [HttpGet]
        public List<Roles> Get() => servicio.Consultar();

        [HttpPost]
        public Roles Post([FromBody] Roles entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Roles Put([FromBody] Roles entidad) => servicio.Modificar(entidad);


        [HttpDelete]
        public Roles Delete(Roles entidad)
        {
            return servicio.Eliminar(entidad);
        }
    }
}