using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class NotificacionesHTMLModel : PageModel
    {
        private INotificaciones_Presentacion? iNotificaciones;
        private IUsuarios_Presentacion? iUsuarios;

        [BindProperty] public List<Notificaciones>? Lista { get; set; }
        [BindProperty] public Notificaciones? Notificacion { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }

        public NotificacionesHTMLModel()
        {
            iNotificaciones = new Notificaciones_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iNotificaciones!.Consultar(); Notificacion = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Notificacion = new Notificaciones(); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Notificacion = Lista!.FirstOrDefault(x => x.Id == data); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Notificacion == null) return; if (Notificacion.Id == 0) Notificacion = iNotificaciones!.Guardar(Notificacion); else Notificacion = iNotificaciones!.Modificar(Notificacion); if (Notificacion.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Notificacion = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Notificacion == null) return; Notificacion = iNotificaciones!.Eliminar(Notificacion); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}