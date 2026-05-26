using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Cliente
{
    public class IndexModel : PageModel
    {
        private IVideojuegos_Presentacion? iVideojuegos;
        private ILogros_Presentacion? iLogros;

        public List<Videojuegos>? MisJuegos { get; set; }
        public List<Logros>? MisLogros { get; set; }
        public string? NombreUsuario { get; set; }
        public int TotalLogros { get; set; }
        public int PuntosTotal { get; set; }
        public int Nivel { get; set; }

        public IndexModel()
        {
            iVideojuegos = new Videojuegos_Presentacion();
            iLogros = new Logros_Presentacion();
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
            int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int usuarioId);

            try
            {
                var todosJuegos = iVideojuegos!.Consultar();
                MisJuegos = todosJuegos.Where(v => v.UsuarioId == usuarioId).ToList();

                var todosLogros = iLogros!.Consultar();
                MisLogros = todosLogros.Where(l =>
                    MisJuegos.Any(j => j.Id == l.VideojuegoId) &&
                    l.EstadoDesbloqueado).ToList();

                TotalLogros = MisLogros.Count;
                PuntosTotal = MisLogros.Sum(l => l.Puntos);
                Nivel = (PuntosTotal / 12000) + 1;
            }
            catch { }
        }
    }
}