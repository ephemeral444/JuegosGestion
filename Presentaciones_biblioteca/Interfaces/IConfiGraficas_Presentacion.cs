using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IConfiGraficas_Presentacion
    {
        List<ConfiGraficas> Consultar();
        ConfiGraficas Guardar(ConfiGraficas entidad);
        ConfiGraficas Modificar(ConfiGraficas entidad);
        ConfiGraficas Eliminar(ConfiGraficas entidad);
    }
}
