using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IGestorArchivos_Presentacion
    {
        List<GestorArchivos> Consultar();
        GestorArchivos Guardar(GestorArchivos entidad);
        GestorArchivos Modificar(GestorArchivos entidad);
        GestorArchivos Eliminar(GestorArchivos entidad);
    }
}
