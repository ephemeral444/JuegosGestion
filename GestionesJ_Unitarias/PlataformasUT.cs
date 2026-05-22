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
        private Plataformas? entidad;

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Consultar();
            Modificar();
            Borrar();
        }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Plataformas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad = new Plataformas()
            {
                NombrePlataforma = "UT-" + DateTime.Now.ToString(),
                TipoPlataforma = "Consola",
                Fabricante = "Test",
                Generacion = "9",
                Descripcion = "Prueba",
                FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now)
            };
            this.iConexion.Plataformas!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.NombrePlataforma = "UT-MOD-" + DateTime.Now.ToString();
            this.iConexion.Plataformas!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Plataformas!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}