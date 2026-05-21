using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class PermisosApli : IPermisosApli
    {
        private IConexion? iConexion;

        public List<Permisos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Permisos!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Permisos";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se consultaron todos los permisos";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public Permisos Guardar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Permisos!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Permisos";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó un permiso";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Permisos Modificar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Permisos!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Permisos";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se modificó un permiso";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Permisos Eliminar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Permisos!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Permisos";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se eliminó un permiso";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
