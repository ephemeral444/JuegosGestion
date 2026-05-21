using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface ISesionesJuegos_Presentacion
    {
        List<SesionesJuegos> Consultar();
        SesionesJuegos Guardar(SesionesJuegos entidad);
        SesionesJuegos Modificar(SesionesJuegos entidad);
        SesionesJuegos Eliminar(SesionesJuegos entidad);
    }
}
