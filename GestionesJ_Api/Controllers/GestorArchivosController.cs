using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorArchivosController : ControllerBase
    {
        private GestorArchivosApli servicio = new GestorArchivosApli();

        [HttpGet]
        public List<GestorArchivos> Get() => servicio.Consultar();

        [HttpPost]
        public GestorArchivos Post([FromBody] GestorArchivos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public GestorArchivos Put([FromBody] GestorArchivos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public GestorArchivos Delete(int id)
        {
            var entidad = new GestorArchivos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
