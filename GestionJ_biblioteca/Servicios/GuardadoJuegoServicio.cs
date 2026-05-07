using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class GuardadoJuegoServicio
    {
        private Conexion db = new Conexion();

        public List<GuardadoJuegos> ObtenerTodos()
        {
            return db.GuardadoJuegos!
                .ToList();
        }

        public GuardadoJuegos Guardar(GuardadoJuegos entidad)
        {

            db.GuardadoJuegos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public GuardadoJuegos Modificar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public GuardadoJuegos Eliminar(GuardadoJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.GuardadoJuegos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
