using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class LogroServicio
    {
        private Conexion db = new Conexion();

        public List<Logros> ObtenerTodos()
        {
            return db.Logros!
                .ToList();
        }

        public Logros Guardar(Logros entidad)
        {

            db.Logros!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Logros Modificar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Logros Eliminar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Logros!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
