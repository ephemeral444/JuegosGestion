using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class PlataformasApli : IPlataformasApli
    {
        private Conexion db = new Conexion();

        public List<Plataformas> Consultar()
        {
            return db.Plataformas!.ToList();
        }

        public Plataformas Guardar(Plataformas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
