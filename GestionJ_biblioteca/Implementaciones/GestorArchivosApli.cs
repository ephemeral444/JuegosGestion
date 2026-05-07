using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class GestorArchivosApli : IGestorArchivosApli
    {
        private Conexion db = new Conexion();

        public List<GestorArchivos> Consultar()
        {
            return db.GestorArchivos!.ToList();
        }

        public GestorArchivos Guardar(GestorArchivos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.GestorArchivos!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public GestorArchivos Modificar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public GestorArchivos Eliminar(GestorArchivos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.GestorArchivos!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
