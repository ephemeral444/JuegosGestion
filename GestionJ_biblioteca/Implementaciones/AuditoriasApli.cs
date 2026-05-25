using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class AuditoriasApli : IAuditoriasApli
    {
        private IConexion? iConexion;

        public List<Auditorias> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Auditorias!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Auditorias";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se consultaron todas las auditorias";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Auditorias!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Auditorias";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó una auditoria";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Auditorias!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Auditorias";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se modificó una auditoria";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Auditorias!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Auditorias";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se eliminó una auditoria";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
