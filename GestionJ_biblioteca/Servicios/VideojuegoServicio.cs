using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class VideojuegosServicio
    {
        private Conexion db = new Conexion();

        public List<Videojuegos> ObtenerTodos()
        {
            return db.Videojuegos!
                .ToList();
        }

        public Videojuegos Guardar(Videojuegos entidad)
        {

            db.Videojuegos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Videojuegos Modificar(Videojuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Videojuegos Eliminar(Videojuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Videojuegos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
