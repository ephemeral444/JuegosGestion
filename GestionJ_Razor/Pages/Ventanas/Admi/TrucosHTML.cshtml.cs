using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class TrucosHTMLModel : PageModel
    {
        private ITrucos_Presentacion? iTrucos;
        private IVideojuegos_Presentacion? iVideojuegos;

        [BindProperty] public List<Trucos>? Lista { get; set; }
        [BindProperty] public Trucos? Truco { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }

        public TrucosHTMLModel()
        {
            iTrucos = new Trucos_Presentacion();
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
                Lista = iTrucos!.Consultar();
                Truco = null;
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
                Truco = new Trucos();
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
                Truco = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Truco == null) return;
                if (Truco.Id == 0)
                    Truco = iTrucos!.Guardar(Truco);
                else
                    Truco = iTrucos!.Modificar(Truco);
                if (Truco.Id == 0) return;
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
                Truco = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Truco == null) return;
                Truco = iTrucos!.Eliminar(Truco);
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