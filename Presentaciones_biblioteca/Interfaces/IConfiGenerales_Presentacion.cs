using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IConfiGenerales_Presentacion
    {
        List<ConfiGenerales> Consultar();
        ConfiGenerales Guardar(ConfiGenerales entidad);
        ConfiGenerales Modificar(ConfiGenerales entidad);
        ConfiGenerales Eliminar(ConfiGenerales entidad);
    }
}
