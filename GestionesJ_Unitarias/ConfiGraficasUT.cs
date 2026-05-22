using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ConfiGraficasUT
    {
        private IConexion? iConexion;
        private ConfiGraficas? entidad;
        private ConfiGenerales? confiGeneral;

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
            var lista = iConexion.ConfiGraficas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.confiGeneral = new ConfiGenerales() { Idioma = "ES", Tema = "Oscuro", Autoguardado = DateOnly.FromDateTime(DateTime.Now), Version = "1.0" };
            this.iConexion.ConfiGenerales!.Add(this.confiGeneral);
            this.iConexion.SaveChanges();

            this.entidad = new ConfiGraficas()
            {
                Resolucion = "1080p",
                Filtros = "Ninguno",
                Shaders = "Default",
                Vsync = true,
                ConfiGeneralId = this.confiGeneral.Id
            };
            this.iConexion.ConfiGraficas!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Resolucion = "4K";
            this.iConexion.ConfiGraficas!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.ConfiGraficas!.Remove(this.entidad!);
            this.iConexion.ConfiGenerales!.Remove(this.confiGeneral!);
            this.iConexion.SaveChanges();
        }
    }
}