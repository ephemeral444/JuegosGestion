using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class SesionesJuegosApli : ISesionesJuegosApli
    {
        private Conexion db = new Conexion();

        public List<SesionesJuegos> Consultar()
        {
            return db.SesionesJuegos!.ToList();
        }

        public SesionesJuegos Guardar(SesionesJuegos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.SesionesJuegos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public SesionesJuegos Modificar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public SesionesJuegos Eliminar(SesionesJuegos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.SesionesJuegos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
