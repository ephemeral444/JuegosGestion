using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class GuardadoJuegosUT
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
            var lista = iConexion.GuardadoJuegos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay guardados");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GuardadoJuegos!.FirstOrDefault(g => g.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el guardado");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GuardadoJuegos!.FirstOrDefault(g => g.Id == 1);
            entidad!.HorasJugadas = "80h";
            iConexion.GuardadoJuegos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.HorasJugadas == "80h") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.GuardadoJuegos!.FirstOrDefault(g => g.Id == 1);
            entidad!.HorasJugadas = "50h";
            iConexion.GuardadoJuegos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}