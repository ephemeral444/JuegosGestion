using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class SesionesJuegosUT
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
            var lista = iConexion.SesionesJuegos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay sesiones");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.SesionesJuegos!.FirstOrDefault(s => s.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la sesion");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.SesionesJuegos!.FirstOrDefault(s => s.Id == 1);
            entidad!.Duracion = "4h";
            iConexion.SesionesJuegos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Duracion == "4h") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.SesionesJuegos!.FirstOrDefault(s => s.Id == 1);
            entidad!.Duracion = "3h 20min";
            iConexion.SesionesJuegos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}