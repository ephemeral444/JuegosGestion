using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class GestorArchivosUT
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
            var lista = iConexion.GestorArchivos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay archivos");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GestorArchivos!.FirstOrDefault(g => g.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el archivo");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GestorArchivos!.FirstOrDefault(g => g.Id == 1);
            entidad!.Tamanio = "800MB";
            iConexion.GestorArchivos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Tamanio == "800MB") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GestorArchivos!.FirstOrDefault(g => g.Id == 1);
            entidad!.Tamanio = "700MB";
            iConexion.GestorArchivos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}