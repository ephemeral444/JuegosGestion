using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class RomServicio
    {
        private Conexion db = new Conexion();

        public List<Roms> ObtenerTodos()
        {
            return db.Roms!
                .ToList();
        }

        public Roms Guardar(Roms entidad)
        {

            db.Roms!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Roms Modificar(Roms entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Roms Eliminar(Roms entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Roms!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
