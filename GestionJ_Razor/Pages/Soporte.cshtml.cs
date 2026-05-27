using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class SoporteModel : PageModel
    {
        private INotificaciones_Presentacion? iNotificaciones;

        public List<Notificaciones>? ListaReportes { get; set; }
        [BindProperty] public string? Titulo { get; set; }
        [BindProperty] public string? Mensaje { get; set; }
        public string? MensajeExito { get; set; }
        public string? MensajeError { get; set; }

        public SoporteModel()
        {
            iNotificaciones = new Notificaciones_Presentacion();
        }

        public void OnGet()
        {
            var sesion = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(sesion))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
            CargarReportes();
        }

        private void CargarReportes()
        {
            var rolId = HttpContext.Session.GetString("RolId");
            if (rolId == "1" || rolId == "3")
            {
                try
                {
                    var todos = iNotificaciones!.Consultar();
                    ListaReportes = todos
                        .Where(n => n.TipoNotificacion == "Soporte")
                        .OrderByDescending(n => n.Fecha)
                        .ToList();
                }
                catch { }
            }
        }

        public void OnPostBtEnviar()
        {
            var sesion = HttpContext.Session.GetString("Usuario");
            if (string.IsNullOrEmpty(sesion))
            {
                HttpContext.Response.Redirect("/");
                return;
            }

            if (string.IsNullOrEmpty(Titulo) || string.IsNullOrEmpty(Mensaje))
            {
                MensajeError = "Por favor completá todos los campos";
                CargarReportes();
                return;
            }

            try
            {
                int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int usuarioId);
                var notificacion = new Notificaciones()
                {
                    Titulo = Titulo,
                    Contenido = "Reporte de soporte",
                    Mensaje = Mensaje,
                    TipoNotificacion = "Soporte",
                    Fecha = DateOnly.FromDateTime(DateTime.Now),
                    UsuarioId = usuarioId
                };
                iNotificaciones!.Guardar(notificacion);
                MensajeExito = "¡Reporte enviado correctamente! Lo revisaremos pronto.";
                Titulo = string.Empty;
                Mensaje = string.Empty;
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
            CargarReportes();
        }
    }
}