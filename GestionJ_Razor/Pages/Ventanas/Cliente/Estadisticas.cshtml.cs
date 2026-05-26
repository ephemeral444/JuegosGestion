using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Cliente
{
    public class EstadisticasModel : PageModel
    {
        private IEstadisticas_Presentacion? iEstadisticas;
        private IVideojuegos_Presentacion? iVideojuegos;
        private ILogros_Presentacion? iLogros;
        private ISesionesJuegos_Presentacion? iSesiones;

        public List<Estadisticas>? MisEstadisticas { get; set; }
        public List<Videojuegos>? MisJuegos { get; set; }
        public List<Logros>? MisLogros { get; set; }
        public List<SesionesJuegos>? MisSesiones { get; set; }
        public string? NombreUsuario { get; set; }
        public int UsuarioId { get; set; }

        public EstadisticasModel()
        {
            iEstadisticas = new Estadisticas_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
            iLogros = new Logros_Presentacion();
            iSesiones = new SesionesJuegos_Presentacion();
        }

        public void OnGet()
        {
            var sesion = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(sesion))
            {
                HttpContext.Response.Redirect("/");
                return;
            }

            NombreUsuario = HttpContext.Session.GetString("UsuarioNombre");
            int usuarioId;
            int.TryParse(HttpContext.Session.GetString("UsuarioId"), out usuarioId);
            UsuarioId = usuarioId;

            try
            {
                var todosJuegos = iVideojuegos!.Consultar();
                MisJuegos = todosJuegos.Where(v => v.UsuarioId == UsuarioId).ToList();

                var todasStats = iEstadisticas!.Consultar();
                MisEstadisticas = todasStats
                    .Where(e => MisJuegos.Any(j => j.Id == e.VideojuegoId))
                    .ToList();

                var todosLogros = iLogros!.Consultar();
                MisLogros = todosLogros
                    .Where(l => l.EstadoDesbloqueado &&
                                MisJuegos.Any(j => j.Id == l.VideojuegoId))
                    .ToList();

                var todasSesiones = iSesiones!.Consultar();
                MisSesiones = todasSesiones
                    .Where(s => s.UsuarioId == UsuarioId)
                    .ToList();
            }
            catch { }
        }
    }
}