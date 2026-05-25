using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class RomsHTMLModel : PageModel
    {
        private IRoms_Presentacion? iRoms;
        private IVideojuegos_Presentacion? iVideojuegos;
        private IEmuladores_Presentacion? iEmuladores;

        [BindProperty] public List<Roms>? Lista { get; set; }
        [BindProperty] public Roms? Rom { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public List<Videojuegos>? ListaVideojuegos { get; set; }
        [BindProperty] public List<Emuladores>? ListaEmuladores { get; set; }

        public RomsHTMLModel()
        {
            iRoms = new Roms_Presentacion();
            iVideojuegos = new Videojuegos_Presentacion();
            iEmuladores = new Emuladores_Presentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iRoms!.Consultar();
                Rom = null;
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
                Rom = new Roms();
                ListaVideojuegos = iVideojuegos!.Consultar();
                ListaEmuladores = iEmuladores!.Consultar();
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
                Rom = Lista!.FirstOrDefault(x => x.Id == data);
                ListaVideojuegos = iVideojuegos!.Consultar();
                ListaEmuladores = iEmuladores!.Consultar();
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
                if (Rom == null) return;
                if (Rom.Id == 0)
                    Rom = iRoms!.Guardar(Rom);
                else
                    Rom = iRoms!.Modificar(Rom);
                if (Rom.Id == 0) return;
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
                Rom = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Rom == null) return;
                Rom = iRoms!.Eliminar(Rom);
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