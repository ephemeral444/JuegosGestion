// Pages/Ventanas/Admi/AuditoriasHTML.cshtml.cs
using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages.Ventanas.Admi
{
    public class AuditoriasHTMLModel : PageModel
    {
        private IAuditorias_Presentacion? iAuditorias;
        [BindProperty] public List<Auditorias>? Lista { get; set; }

        public AuditoriasHTMLModel()
        {
            iAuditorias = new Auditorias_Presentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = iAuditorias!.Consultar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }
    }
}