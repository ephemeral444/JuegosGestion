using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class ConfiGraficaApli : IConfiGraficApli
    {
        private Conexion db = new Conexion();

        public List<ConfiGraficas> Consultar()
        {
            return db.ConfiGraficas!.ToList();
        }

        public ConfiGraficas Guardar(ConfiGraficas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
