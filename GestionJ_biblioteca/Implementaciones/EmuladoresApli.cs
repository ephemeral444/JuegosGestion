using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class EmuladoresApli : IEmuladoresApli
    {
        private Conexion db = new Conexion();

        public List<Emuladores> Consultar()
        {
            return db.Emuladores!.ToList();
        }

        public Emuladores Guardar(Emuladores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Emuladores!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Emuladores Modificar(Emuladores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Emuladores Eliminar(Emuladores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Emuladores!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
