using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class PlataformasUT
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
            var lista = iConexion.Plataformas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("No hay plataformas");
        }

        private void ConsultarPorId()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Plataformas!.FirstOrDefault(p => p.Id == 1);
            if (entidad != null) return;
            throw new Exception("No se encontró la plataforma");
        }

        private void Modificar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Plataformas!.FirstOrDefault(p => p.Id == 1);
            entidad!.NombrePlataforma = "PlayStation 2-MOD";
            iConexion.Plataformas!.Update(entidad);
            iConexion.SaveChanges();
            if (entidad.NombrePlataforma == "PlayStation 2-MOD") return;
            throw new Exception("No se modificó");
        }

        private void Restaurar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var entidad = iConexion.Plataformas!.FirstOrDefault(p => p.Id == 1);
            entidad!.NombrePlataforma = "PlayStation 2";
            iConexion.Plataformas!.Update(entidad);
            iConexion.SaveChanges();
        }
    }
}