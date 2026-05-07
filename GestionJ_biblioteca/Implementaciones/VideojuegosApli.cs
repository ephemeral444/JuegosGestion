using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class VideojuegosApli : IVideojuegosApli
    {
        private Conexion db = new Conexion();

        public List<Videojuegos> Consultar()
        {
            return db.Videojuegos!.ToList();
        }

        public Videojuegos Guardar(Videojuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
