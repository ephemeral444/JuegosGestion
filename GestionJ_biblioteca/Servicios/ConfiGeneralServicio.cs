using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class ConfiGeneralServicio
    {
        private Conexion db = new Conexion();

        public List<ConfiGenerales> ObtenerTodos()
        {
            return db.ConfiGenerales!
                .ToList();
        }

        public ConfiGenerales Guardar(ConfiGenerales entidad)
        {

            db.ConfiGenerales!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public ConfiGenerales Modificar(ConfiGenerales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public ConfiGenerales Eliminar(ConfiGenerales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.ConfiGenerales!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
