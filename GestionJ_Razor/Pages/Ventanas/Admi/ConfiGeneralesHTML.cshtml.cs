using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class ConfiGeneralesHTMLModel : PageModel
    {
        private IConfiGenerales_Presentacion? iConfiGenerales;
        [BindProperty] public List<ConfiGenerales>? Lista { get; set; }
        [BindProperty] public ConfiGenerales? ConfiGeneral { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ConfiGeneralesHTMLModel() { iConfiGenerales = new ConfiGenerales_Presentacion(); }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iConfiGenerales!.Consultar(); ConfiGeneral = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo() { ConfiGeneral = new ConfiGenerales(); Lista = null; Borrando = false; }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); ConfiGeneral = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (ConfiGeneral == null) return; if (ConfiGeneral.Id == 0) ConfiGeneral = iConfiGenerales!.Guardar(ConfiGeneral); else ConfiGeneral = iConfiGenerales!.Modificar(ConfiGeneral); if (ConfiGeneral.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); ConfiGeneral = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (ConfiGeneral == null) return; ConfiGeneral = iConfiGenerales!.Eliminar(ConfiGeneral); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}