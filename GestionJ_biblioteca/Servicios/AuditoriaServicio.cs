using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class AuditoriaServicio
    {
        private Conexion db = new Conexion();

        public List<Auditorias> ObtenerTodos()
        {
            return db.Auditorias!
                .ToList();
        }

        public Auditorias Guardar(Auditorias entidad)
        {

            db.Auditorias!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Auditorias!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
