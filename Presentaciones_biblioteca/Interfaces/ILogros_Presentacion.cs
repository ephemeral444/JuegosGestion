using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface ILogros_Presentacion
    {
        List<Logros> Consultar();
        Logros Guardar(Logros entidad);
        Logros Modificar(Logros entidad);
        Logros Eliminar(Logros entidad);
    }
}
