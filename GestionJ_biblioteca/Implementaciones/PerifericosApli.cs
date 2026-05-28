using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class PerifericosApli : IPerifericosApli
    {
        private IConexion? iConexion;

        public List<Perifericos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Perifericos!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Perifericos";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador consulto todos los perifericos";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public Perifericos Guardar(Perifericos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Perifericos!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Perifericos";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador guardó un periferico";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Perifericos Modificar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Perifericos!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Perifericos";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador modificó un periferico";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Perifericos Eliminar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Perifericos!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Perifericos";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador eliminó un periferico";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
