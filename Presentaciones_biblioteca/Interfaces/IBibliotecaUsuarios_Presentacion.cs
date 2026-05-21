using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IBibliotecaUsuarios_Presentacion
    {
        List<BibliotecaUsuarios> Consultar();
        BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad);
        BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad);
        BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad);
    }
}
