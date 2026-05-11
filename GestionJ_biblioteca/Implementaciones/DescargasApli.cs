using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class DescargasApli : IDescargasApli
    {
        private IConexion? iConexion;

        public List<Descargas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Descargas!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Descargas";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se consultaron todas las descargas";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public Descargas Guardar(Descargas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Logica: usuarios sin suscripcion max 3 descargas activas
            var descargasActivas = iConexion.Descargas!
                .Count(d => d.UsuarioId == entidad.UsuarioId && d.Estado == "Activa");
            var usuario = iConexion.Usuarios!.FirstOrDefault(u => u.Id == entidad.UsuarioId);
            if (usuario != null && !usuario.Suscripcion && descargasActivas >= 3)
                throw new Exception("Sin suscripcion solo puedes tener 3 descargas activas");

            iConexion.Descargas!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Descargas";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó una descarga";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Descargas Modificar(Descargas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Descargas!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Descargas";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se modificó una descarga";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Descargas Eliminar(Descargas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Descargas!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Descargas";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se eliminó una descarga";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}

