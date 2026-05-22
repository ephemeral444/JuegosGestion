using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class PermisosUT
    {
        private IConexion? iConexion;
        private Permisos? entidad;
        private Roles? rol;

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
            var lista = iConexion.Permisos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.rol = new Roles() { NombreRol = "UT-ROL" };
            this.iConexion.Roles!.Add(this.rol);
            this.iConexion.SaveChanges();
            this.entidad = new Permisos()
            {
                NombrePermiso = "UT-" + DateTime.Now.ToString(),
                Descripcion = "Permiso de prueba",
                RolId = this.rol.Id
            };
            this.iConexion.Permisos!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Descripcion = "Modificado";
            this.iConexion.Permisos!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Permisos!.Remove(this.entidad!);
            this.iConexion.Roles!.Remove(this.rol!);
            this.iConexion.SaveChanges();
        }
    }
}