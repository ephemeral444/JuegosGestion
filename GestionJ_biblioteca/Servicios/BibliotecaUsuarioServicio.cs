using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class BibliotecaUsuarioServicio
    {
        private Conexion db = new Conexion();

        public List<BibliotecaUsuarios> ObtenerTodos()
        {
            return db.BibliotecaUsuarios!
                .ToList();
        }

        public BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad)
        {

            db.BibliotecaUsuarios!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.BibliotecaUsuarios!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
