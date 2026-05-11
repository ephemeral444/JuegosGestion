using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class RolServicio
    {
        private Conexion db = new Conexion();

        public List<Roles> ObtenerTodos()
        {
            return db.Roles!
                .ToList();
        }

        public Roles Guardar(Roles entidad)
        {

            db.Roles!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Roles Eliminar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Roles!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
