using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class ConfigAudiosHTMLModel : PageModel
    {
        private IConfigAudios_Presentacion? iConfigAudios;
        private IConfiGenerales_Presentacion? iConfiGenerales;

        [BindProperty] public List<ConfigAudios>? Lista { get; set; }
        [BindProperty] public ConfigAudios? ConfigAudio { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<ConfiGenerales>? ListaConfiGenerales { get; set; }

        public ConfigAudiosHTMLModel()
        {
            iConfigAudios = new ConfigAudios_Presentacion();
            iConfiGenerales = new ConfiGenerales_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iConfigAudios!.Consultar(); ConfigAudio = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { ConfigAudio = new ConfigAudios(); ListaConfiGenerales = iConfiGenerales!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); ConfigAudio = Lista!.FirstOrDefault(x => x.Id == data); ListaConfiGenerales = iConfiGenerales!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (ConfigAudio == null) return; if (ConfigAudio.Id == 0) ConfigAudio = iConfigAudios!.Guardar(ConfigAudio); else ConfigAudio = iConfigAudios!.Modificar(ConfigAudio); if (ConfigAudio.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); ConfigAudio = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (ConfigAudio == null) return; ConfigAudio = iConfigAudios!.Eliminar(ConfigAudio); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}