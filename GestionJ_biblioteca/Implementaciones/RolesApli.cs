using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class RolesApli : IRolesApli
    {
        private Conexion db = new Conexion();

        public List<Roles> Consultar()
        {
            return db.Roles!.ToList();
        }

        public Roles Guardar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
