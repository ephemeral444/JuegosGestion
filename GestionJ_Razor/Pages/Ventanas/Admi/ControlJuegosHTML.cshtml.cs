using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class ControlJuegosHTMLModel : PageModel
    {
        private IControlJuegos_Presentacion? iControlJuegos;
        private IUsuarios_Presentacion? iUsuarios;

        [BindProperty] public List<ControlJuegos>? Lista { get; set; }
        [BindProperty] public ControlJuegos? Control { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }

        public ControlJuegosHTMLModel()
        {
            iControlJuegos = new ControlJuegos_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iControlJuegos!.Consultar(); Control = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Control = new ControlJuegos(); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Control = Lista!.FirstOrDefault(x => x.Id == data); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Control == null) return; if (Control.Id == 0) Control = iControlJuegos!.Guardar(Control); else Control = iControlJuegos!.Modificar(Control); if (Control.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Control = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Control == null) return; Control = iControlJuegos!.Eliminar(Control); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}