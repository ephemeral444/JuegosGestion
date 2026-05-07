using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionesController : ControllerBase
    {
        private GestionesApli servicio = new GestionesApli();

        [HttpGet]
        public List<Gestiones> Get() => servicio.Consultar();

        [HttpPost]
        public Gestiones Post([FromBody] Gestiones entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Gestiones Put([FromBody] Gestiones entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Gestiones Delete(int id)
        {
            var entidad = new Gestiones { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
