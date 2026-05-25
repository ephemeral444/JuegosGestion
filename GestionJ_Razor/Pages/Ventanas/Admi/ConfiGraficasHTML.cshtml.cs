using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class ConfiGraficasHTMLModel : PageModel
    {
        private IConfiGraficas_Presentacion? iConfiGraficas;
        private IConfiGenerales_Presentacion? iConfiGenerales;

        [BindProperty] public List<ConfiGraficas>? Lista { get; set; }
        [BindProperty] public ConfiGraficas? ConfiGrafica { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<ConfiGenerales>? ListaConfiGenerales { get; set; }

        public ConfiGraficasHTMLModel()
        {
            iConfiGraficas = new ConfiGraficas_Presentacion();
            iConfiGenerales = new ConfiGenerales_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iConfiGraficas!.Consultar(); ConfiGrafica = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { ConfiGrafica = new ConfiGraficas(); ListaConfiGenerales = iConfiGenerales!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); ConfiGrafica = Lista!.FirstOrDefault(x => x.Id == data); ListaConfiGenerales = iConfiGenerales!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (ConfiGrafica == null) return; if (ConfiGrafica.Id == 0) ConfiGrafica = iConfiGraficas!.Guardar(ConfiGrafica); else ConfiGrafica = iConfiGraficas!.Modificar(ConfiGrafica); if (ConfiGrafica.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); ConfiGrafica = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (ConfiGrafica == null) return; ConfiGrafica = iConfiGraficas!.Eliminar(ConfiGrafica); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}