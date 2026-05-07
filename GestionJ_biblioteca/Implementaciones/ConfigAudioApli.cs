using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Implementaciones
{
    public class ConfigAudioApli : IAudioConfigApli
    {
        private Conexion db = new Conexion();

        public List<ConfigAudios> Consultar()
        {
            return db.ConfigAudios!.ToList();
        }

        public ConfigAudios Guardar(ConfigAudios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya existe");

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
