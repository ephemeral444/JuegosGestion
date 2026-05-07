using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IAudioConfigApli
    {
        List<ConfigAudios> Consultar();
        ConfigAudios Guardar(ConfigAudios entidad);
        ConfigAudios Modificar(ConfigAudios entidad);
        ConfigAudios Eliminar(ConfigAudios entidad);
    }
}
