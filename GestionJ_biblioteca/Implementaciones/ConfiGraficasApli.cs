using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class ConfiGraficasApli : IConfiGraficApli
    {
        private IConexion? iConexion;

        public List<ConfiGraficas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.ConfiGraficas!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "ConfiGraficas";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se consultaron todas las configuraciones graficas";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public ConfiGraficas Guardar(ConfiGraficas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.ConfiGraficas!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "ConfiGraficas";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó una configuracion grafica";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public ConfiGraficas Modificar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.ConfiGraficas!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "ConfiGraficas";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se modificó una configuracion grafica";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public ConfiGraficas Eliminar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.ConfiGraficas!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "ConfiGraficas";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se eliminó una configuracion grafica";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
