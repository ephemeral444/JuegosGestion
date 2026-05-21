using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IPermisos_Presentacion
    {
        List<Permisos> Consultar();
        Permisos Guardar(Permisos entidad);
        Permisos Modificar(Permisos entidad);
        Permisos Eliminar(Permisos entidad);
    }
}
