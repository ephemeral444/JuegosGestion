using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class RomsApli : IRomsApli
    {
        private Conexion db = new Conexion();

        public List<Roms> Consultar()
        {
            return db.Roms!.ToList();
        }

        public Roms Guardar(Roms entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
