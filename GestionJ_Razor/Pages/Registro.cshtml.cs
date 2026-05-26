using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class RegistroModel : PageModel
    {
        private IUsuarios_Presentacion? iUsuarios;
        private IPerifericos_Presentacion? iPerifericos;
        private IGestorArchivos_Presentacion? iGestorArchivos;

        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Apellido { get; set; }
        [BindProperty] public string? Telefono { get; set; }
        [BindProperty] public int Edad { get; set; }
        [BindProperty] public string? Pais { get; set; }
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        [BindProperty] public string? ConfirmarContrasena { get; set; }

        public string? MensajeError { get; set; }
        public string? MensajeExito { get; set; }

        public RegistroModel()
        {
            iUsuarios = new Usuarios_Presentacion();
            iPerifericos = new Perifericos_Presentacion();
            iGestorArchivos = new GestorArchivos_Presentacion();
        }

        public void OnGet() { }

        public void OnPostBtRegistrar()
        {
            try
            {
                if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Correo) ||
                    string.IsNullOrEmpty(Contrasena) || string.IsNullOrEmpty(ConfirmarContrasena))
                {
                    MensajeError = "Todos los campos son obligatorios";
                    return;
                }

                if (Contrasena != ConfirmarContrasena)
                {
                    MensajeError = "Las contraseñas no coinciden";
                    return;
                }

                // Verificar que el correo no exista
                var lista = iUsuarios!.Consultar();
                if (lista.Any(u => u.Correo == Correo))
                {
                    MensajeError = "Ya existe un usuario con ese correo";
                    return;
                }

                // Tomar el primer periferico y gestor disponible
                var perifericos = iPerifericos!.Consultar();
                var gestores = iGestorArchivos!.Consultar();

                if (!perifericos.Any() || !gestores.Any())
                {
                    MensajeError = "Error al registrar, contacte al administrador";
                    return;
                }

                var nuevoUsuario = new Usuarios()
                {
                    Nombre = Nombre,
                    Apellido = Apellido ?? "",
                    Telefono = Telefono ?? "",
                    Edad = Edad,
                    Pais = Pais ?? "",
                    Correo = Correo,
                    Contrasena = Contrasena,
                    TargetaCredito = "",
                    Suscripcion = false,
                    PuntosTotal = 0,
                    Nivel = 1,
                    RolId = 2, // Cliente por defecto
                    PerifericoId = perifericos.First().Id,
                    GestorArchivoId = gestores.First().Id
                };

                iUsuarios.Guardar(nuevoUsuario);

                MensajeExito = "¡Registro exitoso! Ya podés iniciar sesión.";

                // Limpiar campos
                Nombre = string.Empty;
                Apellido = string.Empty;
                Telefono = string.Empty;
                Correo = string.Empty;
                Contrasena = string.Empty;
                ConfirmarContrasena = string.Empty;
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
        }
    }
}
