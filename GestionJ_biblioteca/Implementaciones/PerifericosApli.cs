using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class PerifericosApli : IPerifericosApli
    {
        private Conexion db = new Conexion();

        public List<Perifericos> Consultar()
        {
            return db.Perifericos!.ToList();
        }

        public Perifericos Guardar(Perifericos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Perifericos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Perifericos Modificar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Perifericos Eliminar(Perifericos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Perifericos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
