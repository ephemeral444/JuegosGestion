using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ConfigAudiosUT
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
            var lista = iConexion.ConfigAudios!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay configuraciones de audio");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfigAudios!.FirstOrDefault(c => c.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la configuracion de audio");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfigAudios!.FirstOrDefault(c => c.Id == 1);
            entidad!.Volumen = 100;
            iConexion.ConfigAudios!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Volumen == 100) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.ConfigAudios!.FirstOrDefault(c => c.Id == 1);
            entidad!.Volumen = 80;
            iConexion.ConfigAudios!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}