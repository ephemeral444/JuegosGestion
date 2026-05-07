using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class GestorArchivoServicio
    {
        private Conexion db = new Conexion();

        public List<GestorArchivos> ObtenerTodos()
        {
            return db.GestorArchivos!
                .ToList();
        }

        public GestorArchivos Guardar(GestorArchivos entidad)
        {

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
