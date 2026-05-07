using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DescargasController : ControllerBase
    {
        private DescargasApli servicio = new DescargasApli();

        [HttpGet]
        public List<Descargas> Get() => servicio.Consultar();

        [HttpPost]
        public Descargas Post([FromBody] Descargas entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Descargas Put([FromBody] Descargas entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Descargas Delete(int id)
        {
            var entidad = new Descargas { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
