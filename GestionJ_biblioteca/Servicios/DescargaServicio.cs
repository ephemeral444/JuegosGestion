using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class DescargaServicio
    {
        private Conexion db = new Conexion();

        public List<Descargas> ObtenerTodos()
        {
            return db.Descargas!
                .ToList();
        }

        public Descargas Guardar(Descargas entidad)
        {

            db.Descargas!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Descargas Modificar(Descargas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Descargas Eliminar(Descargas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Descargas!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
