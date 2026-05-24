using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class TrucosUT
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
            var lista = iConexion.Trucos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay trucos");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Trucos!.FirstOrDefault(t => t.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el truco");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Trucos!.FirstOrDefault(t => t.Id == 1);
            entidad!.Activo = false;
            iConexion.Trucos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Activo == false) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Trucos!.FirstOrDefault(t => t.Id == 1);
            entidad!.Activo = true;
            iConexion.Trucos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}