using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class GuardadoJuegosHTMLModel : PageModel
    {
        private IGuardadoJuegos_Presentacion? iGuardado;
        private IUsuarios_Presentacion? iUsuarios;
        private IVideojuegos_Presentacion? iVideojuegos;

        [BindProperty] public List<GuardadoJuegos>? Lista { get; set; }
        [BindProperty] public GuardadoJuegos? Guardado { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }

        public GuardadoJuegosHTMLModel()
        {
            iGuardado = new GuardadoJuegos_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iGuardado!.Consultar(); Guardado = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Guardado = new GuardadoJuegos(); ListaUsuarios = iUsuarios!.Consultar(); ListaVideojuegos = iVideojuegos!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Guardado = Lista!.FirstOrDefault(x => x.Id == data); ListaUsuarios = iUsuarios!.Consultar(); ListaVideojuegos = iVideojuegos!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Guardado == null) return; if (Guardado.Id == 0) Guardado = iGuardado!.Guardar(Guardado); else Guardado = iGuardado!.Modificar(Guardado); if (Guardado.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Guardado = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Guardado == null) return; Guardado = iGuardado!.Eliminar(Guardado); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}