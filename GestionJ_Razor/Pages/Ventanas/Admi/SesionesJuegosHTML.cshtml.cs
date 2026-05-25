using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class SesionesJuegosHTMLModel : PageModel
    {
        private ISesionesJuegos_Presentacion? iSesiones;
        private IVideojuegos_Presentacion? iVideojuegos;
        private IUsuarios_Presentacion? iUsuarios;

        [BindProperty] public List<SesionesJuegos>? Lista { get; set; }
        [BindProperty] public SesionesJuegos? Sesion { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }

        public SesionesJuegosHTMLModel()
        {
            iSesiones = new SesionesJuegos_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iSesiones!.Consultar(); Sesion = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Sesion = new SesionesJuegos(); ListaVideojuegos = iVideojuegos!.Consultar(); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Sesion = Lista!.FirstOrDefault(x => x.Id == data); ListaVideojuegos = iVideojuegos!.Consultar(); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Sesion == null) return; if (Sesion.Id == 0) Sesion = iSesiones!.Guardar(Sesion); else Sesion = iSesiones!.Modificar(Sesion); if (Sesion.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Sesion = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Sesion == null) return; Sesion = iSesiones!.Eliminar(Sesion); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}