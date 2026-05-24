using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class DescargasUT
    {
        private IConexion? iConexion;

        [TestMethod]
        public void Ejecutar()
        {
            Consultar();
            ConsultarPorServidor();
            Modificar();
            Restaurar();
        }

        private void Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Descargas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay descargas");
        }

        private void ConsultarPorServidor()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Descargas!.FirstOrDefault(d => d.Servidor == "Server-CO-1");
            if (entidad != null) return;
            throw new Exception("No se encontró la descarga");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Descargas!.FirstOrDefault(d => d.Servidor == "Server-CO-1");
            entidad!.EstadoDescarga = "Pausada";
            iConexion.Descargas!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.EstadoDescarga == "Pausada") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Descargas!.FirstOrDefault(d => d.Servidor == "Server-CO-1");
            entidad!.EstadoDescarga = "Completada";
            iConexion.Descargas!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}