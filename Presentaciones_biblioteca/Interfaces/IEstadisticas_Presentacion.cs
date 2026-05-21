using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IEstadisticas_Presentacion
    {
        List<Estadisticas> Consultar();
        Estadisticas Guardar(Estadisticas entidad);
        Estadisticas Modificar(Estadisticas entidad);
        Estadisticas Eliminar(Estadisticas entidad);
    }
}
