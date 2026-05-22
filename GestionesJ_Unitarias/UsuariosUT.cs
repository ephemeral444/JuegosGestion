using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class UsuariosUT
    {
        private IConexion? iConexion;
        private Usuarios? entidad;
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
            var lista = iConexion.Usuarios!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Crear dependencias
            this.rol = new Roles() { NombreRol = "UT-ROL" };
            this.iConexion.Roles!.Add(this.rol);

            this.periferico = new Perifericos() { Video = true, Audio = true, Teclado = true, Raton = true, Mando = false };
            this.iConexion.Perifericos!.Add(this.periferico);

            this.gestorArchivo = new GestorArchivos() { NombreArchivo = "UT-ARCH", TipoArchivo = "ROM", Tamanio = "1GB", RutaArchivo = "/test" };
            this.iConexion.GestorArchivos!.Add(this.gestorArchivo);

            this.iConexion.SaveChanges();

            this.entidad = new Usuarios()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Apellido = "Test",
                Telefono = "3001234567",
                Edad = 20,
                Pais = "Colombia",
                Correo = "ut@test.com",
                Contrasena = "1234",
                TargetaCredito = "1234567890",
                Suscripcion = false,
                PuntosTotal = 0,
                Nivel = 1,
                RolId = this.rol.Id,
                PerifericoId = this.periferico.Id,
                GestorArchivoId = this.gestorArchivo.Id
            };
            this.iConexion.Usuarios!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Suscripcion = true;
            this.iConexion.Usuarios!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Usuarios!.Remove(this.entidad!);
            this.iConexion.Roles!.Remove(this.rol!);
            this.iConexion.Perifericos!.Remove(this.periferico!);
            this.iConexion.GestorArchivos!.Remove(this.gestorArchivo!);
            this.iConexion.SaveChanges();
        }
    }
}