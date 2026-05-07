using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class NotificacionServicio
    {
        private Conexion db = new Conexion();

        public List<Notificaciones> ObtenerTodos()
        {
            return db.Notificaciones!
                .ToList();
        }

        public Notificaciones Guardar(Notificaciones entidad)
        {

            db.Notificaciones!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Notificaciones Modificar(Notificaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Notificaciones Eliminar(Notificaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Notificaciones!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
