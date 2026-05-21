using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IConfigAudios_Presentacion
    {
        List<ConfigAudios> Consultar();
        ConfigAudios Guardar(ConfigAudios entidad);
        ConfigAudios Modificar(ConfigAudios entidad);
        ConfigAudios Eliminar(ConfigAudios entidad);
    }
}
