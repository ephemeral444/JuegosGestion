using GestionJ_biblioteca.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class EmuladoresModel : PageModel
    {
        private IEmuladores_Presentacion? iEmuladores;
        private IPlataformas_Presentacion? iPlataformas;

        public List<Emuladores>? ListaEmuladores { get; set; }
        public List<Plataformas>? ListaPlataformas { get; set; }

        [BindProperty] public Emuladores? Emulador { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public EmuladoresModel()
        {
            iEmuladores = new Emuladores_Presentacion();
            iPlataformas = new Plataformas_Presentacion();
        }

        public void OnGet()
        {
            try
            {
                ListaEmuladores = iEmuladores!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
            }
            catch { }
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                ListaEmuladores = iEmuladores!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
                Emulador = null;
                Borrando = false;
            }
            catch { }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Emulador = new Emuladores();
                ListaEmuladores = iEmuladores!.Consultar();
                ListaPlataformas = iPlataformas!.Consultar();
            }
            catch { }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Emulador = ListaEmuladores!.FirstOrDefault(x => x.Id == data);
                ListaEmuladores = null;
            }
            catch { }
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
                OnPostBtRefrescar();
            }
            catch { }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Emulador = ListaEmuladores!.FirstOrDefault(x => x.Id == data);
                ListaEmuladores = null;
                Borrando = true;
            }
            catch { }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Emulador == null) return;
                iEmuladores!.Eliminar(Emulador);
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