using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class JuegosModel : PageModel
    {
        private IVideojuegos_Presentacion? iVideojuegos;
        private IPlataformas_Presentacion? iPlataformas;
        private IUsuarios_Presentacion? iUsuarios;
        private IRoms_Presentacion? iRoms;

        public List<Videojuegos>? ListaVideojuegos { get; set; }
        public List<Plataformas>? ListaPlataformas { get; set; }
        public List<Roms>? ListaRoms { get; set; }

        [BindProperty] public Videojuegos? Videojuego { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public JuegosModel()
        {
            iVideojuegos = new Videojuegos_Presentacion();
            iPlataformas = new Plataformas_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
            iRoms = new Roms_Presentacion();
        }

        public void OnGet()
        {
            try
            {
                ListaVideojuegos = iVideojuegos!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
                ListaRoms = iRoms!.Consultar();
            }
            catch { }
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                ListaVideojuegos = iVideojuegos!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
                ListaRoms = iRoms!.Consultar();
                Videojuego = null;
                Borrando = false;
            }
            catch { }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Videojuego = new Videojuegos();
                ListaUsuarios = iUsuarios!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
                ListaVideojuegos = iVideojuegos!.Consultar();
                ListaRoms = iRoms!.Consultar();
            }
            catch { }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Videojuego = ListaVideojuegos!.FirstOrDefault(x => x.Id == data);
                ListaUsuarios = iUsuarios!.Consultar();
                ListaVideojuegos = null;
            }
            catch { }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Videojuego == null) return;
                int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int uid);
                if (Videojuego.Id == 0)
                {
                    Videojuego.UsuarioId = uid;
                    Videojuego = iVideojuegos!.Guardar(Videojuego);
                }
                else
                    Videojuego = iVideojuegos!.Modificar(Videojuego);
                OnPostBtRefrescar();
            }
            catch { }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Videojuego = ListaVideojuegos!.FirstOrDefault(x => x.Id == data);
                ListaVideojuegos = null;
                Borrando = true;
            }
            catch { }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Videojuego == null) return;
                iVideojuegos!.Eliminar(Videojuego);
                OnPostBtRefrescar();
            }
            catch { }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}