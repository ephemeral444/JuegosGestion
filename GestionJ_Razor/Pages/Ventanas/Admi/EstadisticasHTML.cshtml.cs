using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class EstadisticasHTMLModel : PageModel
    {
        private IEstadisticas_Presentacion? iEstadisticas;
        private IVideojuegos_Presentacion? iVideojuegos;

        [BindProperty] public List<Estadisticas>? Lista { get; set; }
        [BindProperty] public Estadisticas? Estadistica { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }

        public EstadisticasHTMLModel()
        {
            iEstadisticas = new Estadisticas_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iEstadisticas!.Consultar(); Estadistica = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Estadistica = new Estadisticas(); ListaVideojuegos = iVideojuegos!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Estadistica = Lista!.FirstOrDefault(x => x.Id == data); ListaVideojuegos = iVideojuegos!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Estadistica == null) return; if (Estadistica.Id == 0) Estadistica = iEstadisticas!.Guardar(Estadistica); else Estadistica = iEstadisticas!.Modificar(Estadistica); if (Estadistica.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Estadistica = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Estadistica == null) return; Estadistica = iEstadisticas!.Eliminar(Estadistica); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}