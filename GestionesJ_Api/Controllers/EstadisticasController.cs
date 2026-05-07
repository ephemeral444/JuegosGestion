using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadisticasController : ControllerBase
    {
        private EstadisticasApli servicio = new EstadisticasApli();

        [HttpGet]
        public List<Estadisticas> Get() => servicio.Consultar();

        [HttpPost]
        public Estadisticas Post([FromBody] Estadisticas entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Estadisticas Put([FromBody] Estadisticas entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Estadisticas Delete(int id)
        {
            var entidad = new Estadisticas { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
