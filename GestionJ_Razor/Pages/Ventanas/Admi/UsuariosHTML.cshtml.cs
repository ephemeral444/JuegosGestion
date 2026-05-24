// Pages/Ventanas/Admi/UsuariosHTML.cshtml.cs
using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class UsuariosHTMLModel : PageModel
    {
        private IUsuarios_Presentacion? iUsuarios;
        private IRoles_Presentacion? iRoles;
        private IPlataformas_Presentacion? iPlataformas;
        private IPerifericos_Presentacion? iPerifericos;
        private IGestorArchivos_Presentacion? iGestorArchivos;

        [BindProperty] public List<Usuarios>? Lista { get; set; }
        [BindProperty] public Usuarios? Usuario { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Roles>? ListaRoles { get; set; }
        [BindProperty] public List<Perifericos>? ListaPerifericos { get; set; }
        [BindProperty] public List<GestorArchivos>? ListaGestorArchivos { get; set; }

        public UsuariosHTMLModel()
        {
            iUsuarios = new Usuarios_Presentacion();
            iRoles = new Roles_Presentacion();
            iPerifericos = new Perifericos_Presentacion();
            iGestorArchivos = new GestorArchivos_Presentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iUsuarios!.Consultar();
                Usuario = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Usuario = new Usuarios();
                ListaRoles = iRoles!.Consultar();
                ListaPerifericos = iPerifericos!.Consultar();
                ListaGestorArchivos = iGestorArchivos!.Consultar();
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Usuario = Lista!.FirstOrDefault(x => x.Id == data);
                ListaRoles = iRoles!.Consultar();
                ListaPerifericos = iPerifericos!.Consultar();
                ListaGestorArchivos = iGestorArchivos!.Consultar();
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Usuario == null) return;
                if (Usuario.Id == 0)
                    Usuario = iUsuarios!.Guardar(Usuario);
                else
                    Usuario = iUsuarios!.Modificar(Usuario);
                if (Usuario.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Usuario = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Usuario == null) return;
                Usuario = iUsuarios!.Eliminar(Usuario);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}