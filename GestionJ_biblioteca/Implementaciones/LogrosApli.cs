using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class LogrosApli : ILogrosApli
    {
        private IConexion? iConexion;

        public List<Logros> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Logros!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Logros";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador consulto todos los logros";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public Logros Guardar(Logros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Logica de puntos segun rareza
            entidad.Puntos = entidad.Rareza switch
            {
                "Bronce" => 100,
                "Plata" => 250,
                "Oro" => 500,
                "Platino" => 1000,
                _ => 0
            };

            iConexion.Logros!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Logros";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador guardó un logro";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Logros Modificar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Recalcular puntos si cambia la rareza
            entidad.Puntos = entidad.Rareza switch
            {
                "Bronce" => 100,
                "Plata" => 250,
                "Oro" => 500,
                "Platino" => 1000,
                _ => 0
            };

            iConexion.Logros!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Logros";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador modificó un logro";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public Logros Eliminar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Logros!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Logros";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador eliminó un logro";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        // Logica para desbloquear logro y sumar puntos al usuario
        public Logros Desbloquear(int usuarioId, Logros entidad)
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            entidad.EstadoDesbloqueado = true;
            entidad.FechaDesbloqueo = DateOnly.FromDateTime(DateTime.Now);
            entidad.Puntos = entidad.Rareza switch
            {
                "Bronce" => 100,
                "Plata" => 250,
                "Oro" => 500,
                "Platino" => 1000,
                _ => 0
            };

            iConexion.Logros!.Update(entidad);

            var usuario = iConexion.Usuarios!.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario != null)
            {
                usuario.PuntosTotal += entidad.Puntos;
                usuario.Nivel = (usuario.PuntosTotal / 12000) + 1;
                iConexion.Usuarios!.Update(usuario);
            }

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "Logros";
            auditoria.Operacion = "Desbloquear";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = $"Se desbloqueó el logro {entidad.NombreLogro} para el usuario {usuarioId}";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}

