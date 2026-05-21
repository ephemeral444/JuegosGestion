// RolesUT.cs
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public class RolesUT
    {
        private IConexion? iConexion;
        private Roles? entidad;

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
            var lista = iConexion.Roles!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad = new Roles()
            {
                NombreRol = "UT-" + DateTime.Now.ToString()
            };
            this.iConexion.Roles!.Add(this.entidad!);
            this.iConexion.SaveChanges();
            if (this.entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.NombreRol = "UT-MOD-" + DateTime.Now.ToString();
            this.iConexion.Roles!.Update(this.entidad!);
            this.iConexion.SaveChanges();
            if (entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Roles!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}