// Pages/Ventanas/Admi/PlataformasHTML.cshtml.cs
using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class PlataformasHTMLModel : PageModel
    {
        private IPlataformas_Presentacion? iPlataformas;
        [BindProperty] public List<Plataformas>? Lista { get; set; }
        [BindProperty] public Plataformas? Plataforma { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PlataformasHTMLModel()
        {
            iPlataformas = new Plataformas_Presentacion();
        }

        public void OnGet()
        {
            // var sesion = HttpContext.Session.GetString("Usuario");
            // if (string.IsNullOrEmpty(sesion))
            // {
            //     HttpContext.Response.Redirect("/");
            //     return;
            // }
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iPlataformas!.Consultar();
                Plataforma = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            Plataforma = new Plataformas();
            Lista = null;
            Borrando = false;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Plataforma = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Plataforma == null) return;
                if (Plataforma.Id == 0)
                    Plataforma = iPlataformas!.Guardar(Plataforma);
                else
                    Plataforma = iPlataformas!.Modificar(Plataforma);
                if (Plataforma.Id == 0) return;
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
                Plataforma = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Plataforma == null) return;
                Plataforma = iPlataformas!.Eliminar(Plataforma);
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