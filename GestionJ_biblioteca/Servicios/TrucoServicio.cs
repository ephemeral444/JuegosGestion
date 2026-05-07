using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class TrucoServicio
    {
        private Conexion db = new Conexion();

        public List<Trucos> ObtenerTodos()
        {
            return db.Trucos!
                .ToList();
        }

        public Trucos Guardar(Trucos entidad)
        {

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
