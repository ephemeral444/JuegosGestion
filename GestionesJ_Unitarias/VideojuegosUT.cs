using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class VideojuegosUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorTitulo();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Videojuegos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay videojuegos");
        }

        private void ConsultarPorTitulo()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Videojuegos!.FirstOrDefault(v => v.Titulo == "God of War II");
            if (entidad != null) return;
            throw new Exception("No se encontró el videojuego");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Videojuegos!.FirstOrDefault(v => v.Titulo == "God of War II");
            entidad!.Completado = true;
            iConexion.Videojuegos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Completado == true) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Videojuegos!.FirstOrDefault(v => v.Titulo == "God of War II");
            entidad!.Completado = false;
            iConexion.Videojuegos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}