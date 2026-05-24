using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class EstadisticasUT
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
            var lista = iConexion.Estadisticas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay estadisticas");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Estadisticas!.FirstOrDefault(e => e.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la estadistica");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Estadisticas!.FirstOrDefault(e => e.Id == 1);
            entidad!.PromedioFPS = 120;
            iConexion.Estadisticas!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.PromedioFPS == 120) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Estadisticas!.FirstOrDefault(e => e.Id == 1);
            entidad!.PromedioFPS = 60;
            iConexion.Estadisticas!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}