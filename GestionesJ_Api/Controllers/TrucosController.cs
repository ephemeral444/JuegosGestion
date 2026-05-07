using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace GestionesJ_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrucosController : ControllerBase
    {
        private TrucosApli servicio = new TrucosApli();

        [HttpGet]
        public List<Trucos> Get() => servicio.Consultar();

        [HttpPost]
        public Trucos Post([FromBody] Trucos entidad) => servicio.Guardar(entidad);

        [HttpPut]
        public Trucos Put([FromBody] Trucos entidad) => servicio.Modificar(entidad);

        [HttpDelete("{id}")]
        public Trucos Delete(int id)
        {
            var entidad = new Trucos { Id = id };
            return servicio.Eliminar(entidad);
        }
    }
}
