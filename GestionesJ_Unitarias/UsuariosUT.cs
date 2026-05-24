using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class UsuariosUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorCorreo();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Usuarios!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay usuarios");
        }

        private void ConsultarPorCorreo()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Usuarios!.FirstOrDefault(u => u.Correo == "carlos@gmail.com");
            if (entidad != null) return;
            throw new Exception("No se encontró el usuario");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Usuarios!.FirstOrDefault(u => u.Correo == "carlos@gmail.com");
            entidad!.Pais = "Mexico";
            iConexion.Usuarios!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Pais == "Mexico") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Usuarios!.FirstOrDefault(u => u.Correo == "carlos@gmail.com");
            entidad!.Pais = "Colombia";
            iConexion.Usuarios!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}