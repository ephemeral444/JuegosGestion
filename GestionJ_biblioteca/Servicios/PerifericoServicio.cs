using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class PerifericoServicio
    {
        private Conexion db = new Conexion();

        public List<Perifericos> ObtenerTodos()
        {
            return db.Perifericos!
                .ToList();
        }

        public Perifericos Guardar(Perifericos entidad)
        {

            db.Perifericos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Perifericos Modificar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Perifericos Eliminar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Perifericos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
