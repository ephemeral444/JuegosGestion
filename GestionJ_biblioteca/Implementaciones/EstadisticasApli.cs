using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class EstadisticasApli : IEstadisticasApli
    {
        private Conexion db = new Conexion();

        public List<Estadisticas> Consultar()
        {
            return db.Estadisticas!.ToList();
        }

        public Estadisticas Guardar(Estadisticas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Estadisticas!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Estadisticas Modificar(Estadisticas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Estadisticas Eliminar(Estadisticas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Estadisticas!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
