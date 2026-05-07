using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class UsuarioServicio
    {
        private Conexion db = new Conexion();

        public List<Usuarios> ObtenerTodos()
        {
            return db.Usuarios!
                .ToList();
        }

        public Usuarios Guardar(Usuarios entidad)
        {

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

        public int CalcularPuntosUsuario(List<Logros> logros)
        {
            int total = 0;

            foreach (var logro in logros)
            {
                switch (logro.Rareza)
                {
                    case "Bronce":
                        total += 250;
                        break;
                    case "Plata":
                        total += 500;
                        break;
                    case "Oro":
                        total += 1000;
                        break;
                    case "Platino":
                        total += 5000;
                        break;
                }
            }
            return total;
        }

        public int CalcularNivel(int puntos)
        {
            return puntos / 10000;
        }

        public int ContarTrofeos(List<Logros> logros)
        {
            return logros.Count;
        }



    }

}
