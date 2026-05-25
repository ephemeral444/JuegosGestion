using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class VideojuegosHTMLModel : PageModel
    {
        private IVideojuegos_Presentacion? iVideojuegos;
        private IUsuarios_Presentacion? iUsuarios;
        private IPlataformas_Presentacion? iPlataformas;

        [BindProperty] public List<Videojuegos>? Lista { get; set; }
        [BindProperty] public Videojuegos? Videojuego { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public List<Plataformas>? ListaPlataformas { get; set; }

        public VideojuegosHTMLModel()
        {
            iVideojuegos = new Videojuegos_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
            iPlataformas = new Plataformas_Presentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iVideojuegos!.Consultar();
                Videojuego = null;
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
                Videojuego = new Videojuegos();
                ListaUsuarios = iUsuarios!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
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
                Videojuego = Lista!.FirstOrDefault(x => x.Id == data);
                ListaUsuarios = iUsuarios!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
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
                if (Videojuego == null) return;
                if (Videojuego.Id == 0)
                    Videojuego = iVideojuegos!.Guardar(Videojuego);
                else
                    Videojuego = iVideojuegos!.Modificar(Videojuego);
                if (Videojuego.Id == 0) return;
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
                Videojuego = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Videojuego == null) return;
                Videojuego = iVideojuegos!.Eliminar(Videojuego);
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