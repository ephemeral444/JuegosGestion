using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class PermisosHTMLModel : PageModel
    {
        private IPermisos_Presentacion? iPermisos;
        private IRoles_Presentacion? iRoles;

        [BindProperty] public List<Permisos>? Lista { get; set; }
        [BindProperty] public Permisos? Permiso { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Roles>? ListaRoles { get; set; }

        public PermisosHTMLModel()
        {
            iPermisos = new Permisos_Presentacion();
            iRoles = new Roles_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try { Lista = iPermisos!.Consultar(); Permiso = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            try { Permiso = new Permisos(); ListaRoles = iRoles!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtModificar(int data)
        {
            try { OnPostBtRefrescar(); Permiso = Lista!.FirstOrDefault(x => x.Id == data); ListaRoles = iRoles!.Consultar(); Lista = null; Borrando = false; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try { if (Permiso == null) return; if (Permiso.Id == 0) Permiso = iPermisos!.Guardar(Permiso); else Permiso = iPermisos!.Modificar(Permiso); if (Permiso.Id == 0) return; OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try { OnPostBtRefrescar(); Permiso = Lista!.FirstOrDefault(x => x.Id == data); Lista = null; Borrando = true; }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try { if (Permiso == null) return; Permiso = iPermisos!.Eliminar(Permiso); OnPostBtRefrescar(); }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar() { OnPostBtRefrescar(); Borrando = false; }
    }
}