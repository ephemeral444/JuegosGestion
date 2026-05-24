using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class NotificacionesUT
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
            var lista = iConexion.Notificaciones!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay notificaciones");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Notificaciones!.FirstOrDefault(n => n.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la notificacion");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Notificaciones!.FirstOrDefault(n => n.Id == 1);
            entidad!.Mensaje = "Mensaje modificado";
            iConexion.Notificaciones!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Mensaje == "Mensaje modificado") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Notificaciones!.FirstOrDefault(n => n.Id == 1);
            entidad!.Mensaje = "Felicitaciones por tu logro Platino";
            iConexion.Notificaciones!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}