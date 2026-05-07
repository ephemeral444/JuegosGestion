using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class LogrosApli : ILogrosApli
    {
        private Conexion db = new Conexion();

        public List<Logros> Consultar()
        {
            return db.Logros!.ToList();
        }

        public Logros Guardar(Logros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Logros!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Logros Modificar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Logros Eliminar(Logros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Logros!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}

