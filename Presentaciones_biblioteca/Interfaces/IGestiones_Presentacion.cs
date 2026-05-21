using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IGestiones_Presentacion
    {
        List<Gestiones> Consultar();
        Gestiones Guardar(Gestiones entidad);
        Gestiones Modificar(Gestiones entidad);
        Gestiones Eliminar(Gestiones entidad);
    }
}
