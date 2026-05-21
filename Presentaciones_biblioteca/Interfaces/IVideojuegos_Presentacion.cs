using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IVideojuegos_Presentacion
    {
        List<Videojuegos> Consultar();
        Videojuegos Guardar(Videojuegos entidad);
        Videojuegos Modificar(Videojuegos entidad);
        Videojuegos Eliminar(Videojuegos entidad);
    }
}
