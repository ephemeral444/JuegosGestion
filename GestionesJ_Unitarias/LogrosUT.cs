using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class LogrosUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorNombre();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Logros!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay logros");
        }

        private void ConsultarPorNombre()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Logros!.FirstOrDefault(l => l.NombreLogro == "Dios de la Guerra");
            if (entidad != null) return;
            throw new Exception("No se encontró el logro");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Logros!.FirstOrDefault(l => l.NombreLogro == "Dios de la Guerra");
            entidad!.Puntos = 1500;
            iConexion.Logros!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Puntos == 1500) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Logros!.FirstOrDefault(l => l.NombreLogro == "Dios de la Guerra");
            entidad!.Puntos = 1000;
            iConexion.Logros!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}