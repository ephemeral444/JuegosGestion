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
        private Emuladores? entidad;
        private Plataformas? plataforma;

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
            var lista = iConexion.Emuladores!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.plataforma = new Plataformas() { NombrePlataforma = "UT-PLAT", TipoPlataforma = "Consola", Fabricante = "Test", Generacion = "9", Descripcion = "Test", FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now) };
            this.iConexion.Plataformas!.Add(this.plataforma);
            this.iConexion.SaveChanges();

            this.entidad = new Emuladores()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Version = 1.0m,
                Bios = "BIOS-TEST",
                RegionBios = "NTSC",
                PlataformaId = this.plataforma.Id
            };
            this.iConexion.Emuladores!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Version = 2.0m;
            this.iConexion.Emuladores!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Emuladores!.Remove(this.entidad!);
            this.iConexion.Plataformas!.Remove(this.plataforma!);
            this.iConexion.SaveChanges();
        }
    }
}