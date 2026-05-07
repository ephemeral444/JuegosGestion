using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class ControlJuegosApli : IControlJuegosApli
    {
        private Conexion db = new Conexion();

        public List<ControlJuegos> Consultar()
        {
            return db.ControlJuegos!.ToList();
        }

        public ControlJuegos Guardar(ControlJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
