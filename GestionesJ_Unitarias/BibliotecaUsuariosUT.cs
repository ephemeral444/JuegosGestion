using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class BibliotecaUsuariosUT
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
            var lista = iConexion.BibliotecaUsuarios!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay bibliotecas");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.BibliotecaUsuarios!.FirstOrDefault(b => b.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la biblioteca");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.BibliotecaUsuarios!.FirstOrDefault(b => b.Id == 1);
            entidad!.HorasJugadas = "150";
            iConexion.BibliotecaUsuarios!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.HorasJugadas == "150") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.BibliotecaUsuarios!.FirstOrDefault(b => b.Id == 1);
            entidad!.HorasJugadas = "120";
            iConexion.BibliotecaUsuarios!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}