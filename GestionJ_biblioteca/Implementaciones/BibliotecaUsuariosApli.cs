using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class BibliotecaUsuariosApli : IBibliotecaUsuariosApli
    {
        private Conexion db = new Conexion();

        public List<BibliotecaUsuarios> Consultar()
        {
            return db.BibliotecaUsuarios!.ToList();
        }

        public BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

            db.BibliotecaUsuarios!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.BibliotecaUsuarios!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
