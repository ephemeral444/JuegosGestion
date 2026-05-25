using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class LogrosHTMLModel : PageModel
    {
        private ILogros_Presentacion? iLogros;
        private IVideojuegos_Presentacion? iVideojuegos;

        [BindProperty] public List<Logros>? Lista { get; set; }
        [BindProperty] public Logros? Logro { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }

        public LogrosHTMLModel()
        {
            iLogros = new Logros_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iLogros!.Consultar();
                Logro = null;
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
                Logro = new Logros();
                ListaVideojuegos = iVideojuegos!.Consultar();
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
                Logro = Lista!.FirstOrDefault(x => x.Id == data);
                ListaVideojuegos = iVideojuegos!.Consultar();
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
                if (Logro == null) return;
                if (Logro.Id == 0)
                    Logro = iLogros!.Guardar(Logro);
                else
                    Logro = iLogros!.Modificar(Logro);
                if (Logro.Id == 0) return;
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
                Logro = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Logro == null) return;
                Logro = iLogros!.Eliminar(Logro);
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