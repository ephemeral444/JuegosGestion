using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionesJuegosController : ControllerBase
    {
        private SesionesJuegosApli servicio = new SesionesJuegosApli();

        [HttpGet]
        public List<SesionesJuegos> Get() => servicio.Consultar();

        [HttpPost]
        public SesionesJuegos Post([FromBody] SesionesJuegos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public SesionesJuegos Put([FromBody] SesionesJuegos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public SesionesJuegos Delete(int id)
        {
            var entidad = new SesionesJuegos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
