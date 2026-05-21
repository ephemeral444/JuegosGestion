using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IDescargas_Presentacion
    {
        List<Descargas> Consultar();
        Descargas Guardar(Descargas entidad);
        Descargas Modificar(Descargas entidad);
        Descargas Eliminar(Descargas entidad);
    }
}
