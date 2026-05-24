using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class EmuladoresUT
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
            var lista = iConexion.Emuladores!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay emuladores");
        }

        private void ConsultarPorNombre()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Emuladores!.FirstOrDefault(e => e.Nombre == "PCSX2");
            if (entidad != null) return;
            throw new Exception("No se encontró el emulador");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Emuladores!.FirstOrDefault(e => e.Nombre == "PCSX2");
            entidad!.RegionBios = "NTSC-U";
            iConexion.Emuladores!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.RegionBios == "NTSC-U") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Emuladores!.FirstOrDefault(e => e.Nombre == "PCSX2");
            entidad!.RegionBios = "NTSC-J";
            iConexion.Emuladores!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}