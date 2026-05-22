using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ConfigAudiosUT
    {
        private IConexion? iConexion;
        private ConfigAudios? entidad;
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
            var lista = iConexion.ConfigAudios!.ToList();
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

            this.entidad = new ConfigAudios()
            {
                Latencia = "50ms",
                Frecuencia = "44100Hz",
                Volumen = 80,
                Modo = "Estereo",
                ConfiGeneralId = this.confiGeneral.Id
            };
            this.iConexion.ConfigAudios!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Volumen = 100;
            this.iConexion.ConfigAudios!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.ConfigAudios!.Remove(this.entidad!);
            this.iConexion.ConfiGenerales!.Remove(this.confiGeneral!);
            this.iConexion.SaveChanges();
        }
    }
}