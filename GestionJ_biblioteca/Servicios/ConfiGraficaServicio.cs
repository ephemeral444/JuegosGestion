using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class ConfiGraficaServicio
    {
        private Conexion db = new Conexion();

        public List<ConfiGraficas> ObtenerTodos()
        {
            return db.ConfiGraficas!
                .ToList();
        }

        public ConfiGraficas Guardar(ConfiGraficas entidad)
        {

            db.ConfiGraficas!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public ConfiGraficas Modificar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public ConfiGraficas Eliminar(ConfiGraficas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.ConfiGraficas!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
