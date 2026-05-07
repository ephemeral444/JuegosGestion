using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class GestionServicio
    {
        private Conexion db = new Conexion();

        public List<Gestiones> ObtenerTodos()
        {
            return db.Gestiones!
                .ToList();
        }

        public Gestiones Guardar(Gestiones entidad)
        {

            db.Gestiones!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Gestiones Modificar(Gestiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Gestiones Eliminar(Gestiones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Gestiones!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
