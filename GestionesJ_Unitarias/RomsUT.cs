using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class RomsUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorNombre();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Roms!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay roms");
        }

        private void ConsultarPorNombre()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roms!.FirstOrDefault(r => r.Nombre == "God of War II NTSC");
            if (entidad != null) return;
            throw new Exception("No se encontró la rom");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roms!.FirstOrDefault(r => r.Nombre == "God of War II NTSC");
            entidad!.TamanioArchivo = "5GB";
            iConexion.Roms!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.TamanioArchivo == "5GB") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Roms!.FirstOrDefault(r => r.Nombre == "God of War II NTSC");
            entidad!.TamanioArchivo = "4.7GB";
            iConexion.Roms!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}