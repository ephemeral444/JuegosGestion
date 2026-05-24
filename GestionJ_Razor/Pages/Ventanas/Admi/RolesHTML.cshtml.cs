using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas
{
    public class RolesHTMLModel : PageModel
    {
        private IRoles_Presentacion? iRoles;
        [BindProperty] public List<Roles>? Lista { get; set; }
        [BindProperty] public Roles? Rol { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public RolesHTMLModel()
        {
            iRoles = new Roles_Presentacion();
        }

        public void OnGet()
        {
            //var sesion = HttpContext.Session.GetString("Usuario");
            //if (string.IsNullOrEmpty(sesion))
            //{
//                HttpContext.Response.Redirect("/");
  //              return;
    //        }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iRoles!.Consultar();
                Rol = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Rol = new Roles();
            Lista = null;
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Rol = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Rol == null) return;
                if (Rol.Id == 0)
                    Rol = iRoles!.Guardar(Rol);
                else
                    Rol = iRoles!.Modificar(Rol);
                if (Rol.Id == 0) return;
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
                Rol = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Rol == null) return;
                Rol = iRoles!.Eliminar(Rol);
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