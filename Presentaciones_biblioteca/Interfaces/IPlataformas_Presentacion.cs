using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IPlataformas_Presentacion
    {
        List<Plataformas> Consultar();
        Plataformas Guardar(Plataformas entidad);
        Plataformas Modificar(Plataformas entidad);
        Plataformas Eliminar(Plataformas entidad);
    }
}
