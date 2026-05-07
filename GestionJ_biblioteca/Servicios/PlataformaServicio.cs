using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class PlataformaServicio
    {
        private Conexion db = new Conexion();

        public List<Plataformas> ObtenerTodos()
        {
            return db.Plataformas!
                .ToList();
        }

        public Plataformas Guardar(Plataformas entidad)
        {

            db.Plataformas!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Plataformas Modificar(Plataformas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Plataformas Eliminar(Plataformas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Plataformas!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
