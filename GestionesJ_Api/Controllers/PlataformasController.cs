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

        [HttpGet]
        public List<Plataformas> Get() => servicio.Consultar();

        [HttpPost]
        public Plataformas Post([FromBody] Plataformas entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Plataformas Put([FromBody] Plataformas entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Plataformas Delete(int id)
        {
            var entidad = new Plataformas { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
