using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class EmuladoresHTMLModel : PageModel
    {
        private IEmuladores_Presentacion? iEmuladores;
        private IPlataformas_Presentacion? iPlataformas;

        [BindProperty] public List<Emuladores>? Lista { get; set; }
        [BindProperty] public Emuladores? Emulador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Plataformas>? ListaPlataformas { get; set; }

        public EmuladoresHTMLModel()
        {
            iEmuladores = new Emuladores_Presentacion();
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
                Lista = iEmuladores!.Consultar();
                Emulador = null;
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
                Emulador = new Emuladores();
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
                Emulador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Emulador == null) return;
                if (Emulador.Id == 0)
                    Emulador = iEmuladores!.Guardar(Emulador);
                else
                    Emulador = iEmuladores!.Modificar(Emulador);
                if (Emulador.Id == 0) return;
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
                Emulador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Emulador == null) return;
                Emulador = iEmuladores!.Eliminar(Emulador);
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