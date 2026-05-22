using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class ControlJuegosUT
    {
        private IConexion? iConexion;
        private ControlJuegos? entidad;
        private Usuarios? usuario;
        private Roles? rol;
        private Perifericos? periferico;
        private GestorArchivos? gestorArchivo;

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
            var lista = iConexion.ControlJuegos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.rol = new Roles() { NombreRol = "UT-ROL" };
            this.iConexion.Roles!.Add(this.rol);
            this.periferico = new Perifericos() { Video = true, Audio = true, Teclado = true, Raton = true, Mando = false };
            this.iConexion.Perifericos!.Add(this.periferico);
            this.gestorArchivo = new GestorArchivos() { NombreArchivo = "UT", TipoArchivo = "ROM", Tamanio = "1GB", RutaArchivo = "/test" };
            this.iConexion.GestorArchivos!.Add(this.gestorArchivo);
            this.iConexion.SaveChanges();
            this.usuario = new Usuarios() { Nombre = "UT", Apellido = "Test", Telefono = "300", Edad = 20, Pais = "CO", Correo = "ut@test.com", Contrasena = "1234", TargetaCredito = "1234", Suscripcion = false, PuntosTotal = 0, Nivel = 1, RolId = this.rol.Id, PerifericoId = this.periferico.Id, GestorArchivoId = this.gestorArchivo.Id };
            this.iConexion.Usuarios!.Add(this.usuario);
            this.iConexion.SaveChanges();
            this.entidad = new ControlJuegos()
            {
                Fps = "60",
                Controles = "Teclado",
                Sensibilidad = 5,
                Dificultad = "Normal",
                UsuarioId = this.usuario.Id
            };
            this.iConexion.ControlJuegos!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Dificultad = "Dificil";
            this.iConexion.ControlJuegos!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.ControlJuegos!.Remove(this.entidad!);
            this.iConexion.Usuarios!.Remove(this.usuario!);
            this.iConexion.Roles!.Remove(this.rol!);
            this.iConexion.Perifericos!.Remove(this.periferico!);
            this.iConexion.GestorArchivos!.Remove(this.gestorArchivo!);
            this.iConexion.SaveChanges();
        }
    }
}