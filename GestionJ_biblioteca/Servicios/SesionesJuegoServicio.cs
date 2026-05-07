using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class SesionesJuegoServicio
    {
        private Conexion db = new Conexion();

        public List<SesionesJuegos> ObtenerTodos()
        {
            return db.SesionesJuegos!
                .ToList();
        }

        public SesionesJuegos Guardar(SesionesJuegos entidad)
        {

            db.SesionesJuegos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public SesionesJuegos Modificar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public SesionesJuegos Eliminar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.SesionesJuegos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
