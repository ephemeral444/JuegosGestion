using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class TrucosApli : ITrucosApli
    {
        private Conexion db = new Conexion();

        public List<Trucos> Consultar()
        {
            return db.Trucos!.ToList();
        }

        public Trucos Guardar(Trucos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Trucos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Trucos Modificar(Trucos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Trucos Eliminar(Trucos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Trucos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
