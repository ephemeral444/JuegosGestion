using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class GestorArchivosHTMLModel : PageModel
    {
        private IGestorArchivos_Presentacion? iGestorArchivos;
        [BindProperty] public List<GestorArchivos>? Lista { get; set; }
        [BindProperty] public GestorArchivos? GestorArchivo { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public GestorArchivosHTMLModel()
        {
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
                Lista = iGestorArchivos!.Consultar();
                GestorArchivo = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            GestorArchivo = new GestorArchivos();
            Lista = null;
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                GestorArchivo = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (GestorArchivo == null) return;
                if (GestorArchivo.Id == 0)
                    GestorArchivo = iGestorArchivos!.Guardar(GestorArchivo);
                else
                    GestorArchivo = iGestorArchivos!.Modificar(GestorArchivo);
                if (GestorArchivo.Id == 0) return;
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
                GestorArchivo = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (GestorArchivo == null) return;
                GestorArchivo = iGestorArchivos!.Eliminar(GestorArchivo);
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