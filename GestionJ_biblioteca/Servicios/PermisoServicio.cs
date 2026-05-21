using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class PermisoServicio
    {
        private Conexion db = new Conexion();

        public List<Permisos> ObtenerTodos()
        {
            return db.Permisos!
                .ToList();
        }

        public Permisos Guardar(Permisos entidad)
        {

            db.Permisos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Permisos Modificar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Permisos Eliminar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Permisos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
