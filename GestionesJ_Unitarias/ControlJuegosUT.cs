using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ControlJuegosUT
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
            var lista = iConexion.ControlJuegos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay controles");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ControlJuegos!.FirstOrDefault(c => c.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el control");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ControlJuegos!.FirstOrDefault(c => c.Id == 1);
            entidad!.Dificultad = "Dificil";
            iConexion.ControlJuegos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Dificultad == "Dificil") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ControlJuegos!.FirstOrDefault(c => c.Id == 1);
            entidad!.Dificultad = "Normal";
            iConexion.ControlJuegos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}