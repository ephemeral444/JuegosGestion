using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class AuditoriasUT
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
            var lista = iConexion.Auditorias!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay auditorias");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Auditorias!.FirstOrDefault(a => a.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la auditoria");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Auditorias!.FirstOrDefault(a => a.Id == 1);
            entidad!.Descripcion = "Modificado";
            iConexion.Auditorias!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.Descripcion == "Modificado") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Auditorias!.FirstOrDefault(a => a.Id == 1);
            entidad!.Descripcion = "Insercion inicial";
            iConexion.Auditorias!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}