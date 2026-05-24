using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class RolesUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorId();
            Modificar();
            RestaurarNombre();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Roles!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay roles");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roles!.FirstOrDefault(r => r.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el rol con Id 1");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roles!.FirstOrDefault(r => r.Id == 1);
            entidad!.NombreRol = "Administrador-MOD";
            iConexion.Roles!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.NombreRol == "Administrador-MOD") return;
            throw new Exception("No se modificó");
        }

        private void RestaurarNombre()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roles!.FirstOrDefault(r => r.Id == 1);
            entidad!.NombreRol = "Administrador";
            iConexion.Roles!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}