using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IRoms_Presentacion
    {
        List<Roms> Consultar();
        Roms Guardar(Roms entidad);
        Roms Modificar(Roms entidad);
        Roms Eliminar(Roms entidad);
    }
}
