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
        private Descargas? entidad;
        private Roms? rom;
        private Videojuegos? videojuego;
        private Emuladores? emulador;
        private Plataformas? plataforma;
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
            var lista = iConexion.Descargas!.ToList();
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
            this.plataforma = new Plataformas() { NombrePlataforma = "UT-PLAT", TipoPlataforma = "Consola", Fabricante = "Test", Generacion = "9", Descripcion = "Test", FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now) };
            this.iConexion.Plataformas!.Add(this.plataforma);
            this.iConexion.SaveChanges();
            this.usuario = new Usuarios() { Nombre = "UT", Apellido = "Test", Telefono = "300", Edad = 20, Pais = "CO", Correo = "ut@test.com", Contrasena = "1234", TargetaCredito = "1234", Suscripcion = true, PuntosTotal = 0, Nivel = 1, RolId = this.rol.Id, PerifericoId = this.periferico.Id, GestorArchivoId = this.gestorArchivo.Id };
            this.iConexion.Usuarios!.Add(this.usuario);
            this.iConexion.SaveChanges();
            this.videojuego = new Videojuegos() { Titulo = "UT", Genero = "Accion", Formato = "Digital", Desarrolladora = "Test", Region = "NTSC", Tamanio = "10GB", FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now), Licencia = true, Completado = false, UsuarioId = this.usuario.Id, PlataformaId = this.plataforma.Id };
            this.iConexion.Videojuegos!.Add(this.videojuego);
            this.emulador = new Emuladores() { Nombre = "UT-EMU", Version = 1.0m, Bios = "BIOS", RegionBios = "NTSC", PlataformaId = this.plataforma.Id };
            this.iConexion.Emuladores!.Add(this.emulador);
            this.iConexion.SaveChanges();
            this.rom = new Roms() { Nombre = "UT-ROM", Genero = "Accion", Desarrolladora = "Test", FechaLanzamiento = DateOnly.FromDateTime(DateTime.Now), TamanioArchivo = "500MB", VideojuegoId = this.videojuego.Id, EmuladorId = this.emulador.Id };
            this.iConexion.Roms!.Add(this.rom);
            this.iConexion.SaveChanges();
            this.entidad = new Descargas()
            {
                Servidor = "Server1",
                VelocidadMB = "10MB/s",
                EstadoDescarga = "Activa",
                FechaInstalacion = DateOnly.FromDateTime(DateTime.Now),
                UsuarioId = this.usuario.Id,
                RomId = this.rom.Id
            };
            this.iConexion.Descargas!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.EstadoDescarga = "Completada";
            this.iConexion.Descargas!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Descargas!.Remove(this.entidad!);
            this.iConexion.Roms!.Remove(this.rom!);
            this.iConexion.Videojuegos!.Remove(this.videojuego!);
            this.iConexion.Emuladores!.Remove(this.emulador!);
            this.iConexion.Usuarios!.Remove(this.usuario!);
            this.iConexion.Roles!.Remove(this.rol!);
            this.iConexion.Perifericos!.Remove(this.periferico!);
            this.iConexion.GestorArchivos!.Remove(this.gestorArchivo!);
            this.iConexion.Plataformas!.Remove(this.plataforma!);
            this.iConexion.SaveChanges();
        }
    }
}