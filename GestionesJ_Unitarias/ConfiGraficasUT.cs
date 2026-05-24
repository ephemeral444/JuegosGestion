using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ConfiGraficasUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorId();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.ConfiGraficas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay configuraciones graficas");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfiGraficas!.FirstOrDefault(c => c.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la configuracion grafica");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfiGraficas!.FirstOrDefault(c => c.Id == 1);
            entidad!.Resolucion = "4K";
            iConexion.ConfiGraficas!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Resolucion == "4K") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfiGraficas!.FirstOrDefault(c => c.Id == 1);
            entidad!.Resolucion = "1080p";
            iConexion.ConfiGraficas!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}