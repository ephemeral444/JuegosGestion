using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class GuardadoJuegosApli : IGuardadoJuegosApli
    {
        private IConexion? iConexion;

        public List<GuardadoJuegos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.GuardadoJuegos!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GuardadoJuegos";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador consulto todos los guardados de juegos";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public GuardadoJuegos Guardar(GuardadoJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GuardadoJuegos!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GuardadoJuegos";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador guardó un guardado de juego";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public GuardadoJuegos Modificar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GuardadoJuegos!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GuardadoJuegos";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador modificó un guardado de juego";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public GuardadoJuegos Eliminar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.GuardadoJuegos!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "GuardadoJuegos";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "El administrador eliminó un guardado de juego";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
