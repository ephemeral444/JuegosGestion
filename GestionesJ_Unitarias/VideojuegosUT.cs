using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class VideojuegosUT
    {
        private IConexion? iConexion;
        private Videojuegos? entidad;
        private Usuarios? usuario;
        private Roles? rol;
        private Perifericos? periferico;
        private GestorArchivos? gestorArchivo;
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
            var lista = iConexion.Videojuegos!.ToList();
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
            this.gestorArchivo = new GestorArchivos() { NombreArchivo = "UT-ARCH", TipoArchivo = "ROM", Tamanio = "1GB", RutaArchivo = "/test" };
            this.iConexion.GestorArchivos!.Add(this.gestorArchivo);
            this.plataforma = new Plataformas() { NombrePlataforma = "UT-PLAT", TipoPlataforma = "Consola", Fabricante = "Test", Generacion = "9", Descripcion = "Test", FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now) };
            this.iConexion.Plataformas!.Add(this.plataforma);
            this.iConexion.SaveChanges();

            this.usuario = new Usuarios() { Nombre = "UT", Apellido = "Test", Telefono = "300", Edad = 20, Pais = "CO", Correo = "ut@test.com", Contrasena = "1234", TargetaCredito = "1234", Suscripcion = false, PuntosTotal = 0, Nivel = 1, RolId = this.rol.Id, PerifericoId = this.periferico.Id, GestorArchivoId = this.gestorArchivo.Id };
            this.iConexion.Usuarios!.Add(this.usuario);
            this.iConexion.SaveChanges();

            this.entidad = new Videojuegos()
            {
                Titulo = "UT-" + DateTime.Now.ToString(),
                Genero = "Accion",
                Formato = "Digital",
                Desarrolladora = "Test",
                Region = "NTSC",
                Tamanio = "10GB",
                FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now),
                Licencia = true,
                Completado = false,
                UsuarioId = this.usuario.Id,
                PlataformaId = this.plataforma.Id
            };
            this.iConexion.Videojuegos!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Completado = true;
            this.iConexion.Videojuegos!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Videojuegos!.Remove(this.entidad!);
            this.iConexion.Usuarios!.Remove(this.usuario!);
            this.iConexion.Roles!.Remove(this.rol!);
            this.iConexion.Perifericos!.Remove(this.periferico!);
            this.iConexion.GestorArchivos!.Remove(this.gestorArchivo!);
            this.iConexion.Plataformas!.Remove(this.plataforma!);
            this.iConexion.SaveChanges();
        }
    }
}