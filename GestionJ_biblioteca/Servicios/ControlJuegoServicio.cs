using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class ControlJuegoServicio
    {
        private Conexion db = new Conexion();

        public List<ControlJuegos> ObtenerTodos()
        {
            return db.ControlJuegos!
                .ToList();
        }

        public ControlJuegos Guardar(ControlJuegos entidad)
        {

            db.ControlJuegos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public ControlJuegos Modificar(ControlJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public ControlJuegos Eliminar(ControlJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.ControlJuegos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
