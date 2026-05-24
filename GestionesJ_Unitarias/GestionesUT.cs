using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class GestionesUT
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
            var lista = iConexion.Gestiones!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay gestiones");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Gestiones!.FirstOrDefault(g => g.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la gestion");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Gestiones!.FirstOrDefault(g => g.Id == 1);
            entidad!.Resultado = false;
            iConexion.Gestiones!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Resultado == false) return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Gestiones!.FirstOrDefault(g => g.Id == 1);
            entidad!.Resultado = true;
            iConexion.Gestiones!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}