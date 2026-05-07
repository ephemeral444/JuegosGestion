using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class EmuladorServicio
    {
        private Conexion db = new Conexion();

        public List<Emuladores> ObtenerTodos()
        {
            return db.Emuladores!
                .ToList();
        }

        public Emuladores Guardar(Emuladores entidad)
        {

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
