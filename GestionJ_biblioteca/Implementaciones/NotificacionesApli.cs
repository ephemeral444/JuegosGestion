using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class NotificacionesApli : INotificacionesApli
    {
        private Conexion db = new Conexion();

        public List<Notificaciones> Consultar()
        {
            return db.Notificaciones!.ToList();
        }

        public Notificaciones Guardar(Notificaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
