using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IAuditorias_Presentacion
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Eliminar(Auditorias entidad);
    }
}
