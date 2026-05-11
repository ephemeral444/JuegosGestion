using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Nucleos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class BibliotecaUsuariosApli : IBibliotecaUsuariosApli
    {
        private IConexion? iConexion;

        public List<BibliotecaUsuarios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.BibliotecaUsuarios!.ToList();

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "BibliotecaUsuarios";
            auditoria.Operacion = "Consultar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se consultaron todas las bibliotecas de usuarios";
            iConexion.Auditorias!.Add(auditoria);
            iConexion.SaveChanges();

            return lista;
        }

        public BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.BibliotecaUsuarios!.Add(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "BibliotecaUsuarios";
            auditoria.Operacion = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó una biblioteca de usuario";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.BibliotecaUsuarios!.Update(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "BibliotecaUsuarios";
            auditoria.Operacion = "Modificar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se modificó una biblioteca de usuario";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.BibliotecaUsuarios!.Remove(entidad);

            var auditoria = new Auditorias();
            auditoria.NombreTabla = "BibliotecaUsuarios";
            auditoria.Operacion = "Eliminar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se eliminó una biblioteca de usuario";
            iConexion.Auditorias!.Add(auditoria);

            iConexion.SaveChanges();
            return entidad;
        }
    }

}
