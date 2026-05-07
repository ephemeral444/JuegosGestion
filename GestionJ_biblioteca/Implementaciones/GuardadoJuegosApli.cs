using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class GuardadoJuegosApli : IGuardadoJuegosApli
    {
        private Conexion db = new Conexion();

        public List<GuardadoJuegos> Consultar()
        {
            return db.GuardadoJuegos!.ToList();
        }

        public GuardadoJuegos Guardar(GuardadoJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
