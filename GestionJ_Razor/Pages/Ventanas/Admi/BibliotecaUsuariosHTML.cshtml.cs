using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class BibliotecaUsuariosHTMLModel : PageModel
    {
        private IBibliotecaUsuarios_Presentacion? iBiblioteca;
        private IUsuarios_Presentacion? iUsuarios;

        [BindProperty] public List<BibliotecaUsuarios>? Lista { get; set; }
        [BindProperty] public BibliotecaUsuarios? Biblioteca { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }

        public BibliotecaUsuariosHTMLModel()
        {
            iBiblioteca = new BibliotecaUsuarios_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iBiblioteca!.Consultar(); Biblioteca = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Biblioteca = new BibliotecaUsuarios(); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Biblioteca = Lista!.FirstOrDefault(x => x.Id == data); ListaUsuarios = iUsuarios!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Biblioteca == null) return; if (Biblioteca.Id == 0) Biblioteca = iBiblioteca!.Guardar(Biblioteca); else Biblioteca = iBiblioteca!.Modificar(Biblioteca); if (Biblioteca.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Biblioteca = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Biblioteca == null) return; Biblioteca = iBiblioteca!.Eliminar(Biblioteca); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}