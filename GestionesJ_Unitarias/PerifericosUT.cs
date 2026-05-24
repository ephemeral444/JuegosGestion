using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class PerifericosUT
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
            var lista = iConexion.Perifericos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay perifericos");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Perifericos!.FirstOrDefault(p => p.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró el periferico");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Perifericos!.FirstOrDefault(p => p.Id == 1);
            entidad!.Mando = true;
            iConexion.Perifericos!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Mando == true) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Perifericos!.FirstOrDefault(p => p.Id == 1);
            entidad!.Mando = false;
            iConexion.Perifericos!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}