using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class GestionesApli : IGestionesApli
    {
        private Conexion db = new Conexion();

        public List<Gestiones> Consultar()
        {
            return db.Gestiones!.ToList();
        }

        public Gestiones Guardar(Gestiones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
