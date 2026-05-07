using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class UsuariosApli : IUsuariosApli
    {
        private Conexion db = new Conexion();

        public List<Usuarios> Consultar()
        {
            return db.Usuarios!.ToList();
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.Usuarios!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public Usuarios Eliminar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Usuarios!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
