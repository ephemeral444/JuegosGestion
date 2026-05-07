using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class DescargasApli : IDescargasApli
    {
        private Conexion db = new Conexion();

        public List<Descargas> Consultar()
        {
            return db.Descargas!.ToList();
        }

        public Descargas Guardar(Descargas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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

