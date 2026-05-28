using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class GestorArchivosApli : IGestorArchivosApli
    {
        private IConexion? iConexion;

        public List<GestorArchivos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.GestorArchivos!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GestorArchivos";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador consulto todos los archivos";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public GestorArchivos Guardar(GestorArchivos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GestorArchivos!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GestorArchivos";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador guardó un archivo";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public GestorArchivos Modificar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GestorArchivos!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GestorArchivos";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador modificó un archivo";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public GestorArchivos Eliminar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GestorArchivos!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GestorArchivos";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador eliminó un archivo";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
