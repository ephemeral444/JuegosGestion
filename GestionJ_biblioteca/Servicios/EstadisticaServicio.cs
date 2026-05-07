using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class EstadisticaServicio
    {
        private Conexion db = new Conexion();

        public List<Estadisticas> ObtenerTodos()
        {
            return db.Estadisticas!
                .ToList();
        }

        public Estadisticas Guardar(Estadisticas entidad)
        {

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
