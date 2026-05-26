using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Cliente
{
    public class BibliotecaModel : PageModel
    {
        private IVideojuegos_Presentacion? iVideojuegos;
        private ILogros_Presentacion? iLogros;
        private IDescargas_Presentacion? iDescargas;

        public List<Videojuegos>? MisJuegos { get; set; }
        public List<Logros>? TodosLogros { get; set; }
        public List<Descargas>? MisDescargas { get; set; }
        public string? NombreUsuario { get; set; }
        public int UsuarioId { get; set; }

        public BibliotecaModel()
        {
            iVideojuegos = new Videojuegos_Presentacion();
            iLogros = new Logros_Presentacion();
            iDescargas = new Descargas_Presentacion();
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
                var todos = iVideojuegos!.Consultar();
                MisJuegos = todos.Where(v => v.UsuarioId == UsuarioId).ToList();
                TodosLogros = iLogros!.Consultar();
                MisDescargas = iDescargas!.Consultar()
                    .Where(d => d.UsuarioId == UsuarioId).ToList();
            }
            catch { }
        }
    }
}