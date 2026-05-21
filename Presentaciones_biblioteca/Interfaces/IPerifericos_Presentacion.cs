using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IPerifericos_Presentacion
    {
        List<Perifericos> Consultar();
        Perifericos Guardar(Perifericos entidad);
        Perifericos Modificar(Perifericos entidad);
        Perifericos Eliminar(Perifericos entidad);
    }
}
