using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrafiConfiController : ControllerBase
    {
        private ConfiGraficaApli servicio = new ConfiGraficaApli();

        [HttpGet]
        public List<ConfiGraficas> Get() => servicio.Consultar();

        [HttpPost]
        public ConfiGraficas Post([FromBody] ConfiGraficas entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public ConfiGraficas Put([FromBody] ConfiGraficas entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public ConfiGraficas Delete(int id)
        {
            var entidad = new ConfiGraficas { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
