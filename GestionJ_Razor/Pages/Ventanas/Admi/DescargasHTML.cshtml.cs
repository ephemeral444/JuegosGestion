using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class DescargasHTMLModel : PageModel
    {
        private IDescargas_Presentacion? iDescargas;
        private IUsuarios_Presentacion? iUsuarios;
        private IRoms_Presentacion? iRoms;

        [BindProperty] public List<Descargas>? Lista { get; set; }
        [BindProperty] public Descargas? Descarga { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public List<Roms>? ListaRoms { get; set; }

        public DescargasHTMLModel()
        {
            iDescargas = new Descargas_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
            iRoms = new Roms_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iDescargas!.Consultar(); Descarga = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Descarga = new Descargas(); ListaUsuarios = iUsuarios!.Consultar(); ListaRoms = iRoms!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Descarga = Lista!.FirstOrDefault(x => x.Id == data); ListaUsuarios = iUsuarios!.Consultar(); ListaRoms = iRoms!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Descarga == null) return; if (Descarga.Id == 0) Descarga = iDescargas!.Guardar(Descarga); else Descarga = iDescargas!.Modificar(Descarga); if (Descarga.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Descarga = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Descarga == null) return; Descarga = iDescargas!.Eliminar(Descarga); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}