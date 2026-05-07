using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Servicios
{
    public class ConfigAudioServicio
    {
        private Conexion db = new Conexion();

        public List<ConfigAudios> ObtenerTodos()
        {
            return db.ConfigAudios!
                .ToList();
        }

        public ConfigAudios Guardar(ConfigAudios entidad)
        {

            db.ConfigAudios!.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public ConfigAudios Modificar(ConfigAudios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public ConfigAudios Eliminar(ConfigAudios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("Id inválido");

            db.ConfigAudios!.Remove(entidad);
            db.SaveChanges();
            return entidad;
        }
    }

}
