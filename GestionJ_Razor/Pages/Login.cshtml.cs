using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class LoginModel : PageModel
    {
        private IUsuarios_Presentacion? iUsuarios;

        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        public string? MensajeError { get; set; }

        public LoginModel()
        {
            iUsuarios = new Usuarios_Presentacion();
        }

        public void OnGet() { }

        public void OnPostBtLimpiar()
        {
            Correo = string.Empty;
            Contrasena = string.Empty;
        }

        public void OnPostBtEntrar()
        {
            try
            {
                if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Contrasena))
                {
                    MensajeError = "Por favor ingrese correo y contraseña";
                    return;
                }

                var lista = iUsuarios!.Consultar();
                var usuario = lista.FirstOrDefault(u =>
                    u.Correo == Correo &&
                    u.Contrasena == Contrasena);

                if (usuario == null)
                {
                    MensajeError = "Correo o contraseña incorrectos";
                    return;
                }

                // Guardar sesion
                HttpContext.Session.SetString("Usuario", usuario.Correo!);
                HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre!);
                HttpContext.Session.SetString("RolId", usuario.RolId.ToString());

                // Redirigir segun rol
                if (usuario.RolId == 1)
                    HttpContext.Response.Redirect("/Ventanas/Admi/Index");
                else
                    HttpContext.Response.Redirect("/Ventanas/Cliente/Index");
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            HttpContext.Session.Clear();
            HttpContext.Response.Redirect("/Login");
        }
    }
}