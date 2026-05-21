using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IGuardadoJuegos_Presentacion
    {
        List<GuardadoJuegos> Consultar();
        GuardadoJuegos Guardar(GuardadoJuegos entidad);
        GuardadoJuegos Modificar(GuardadoJuegos entidad);
        GuardadoJuegos Eliminar(GuardadoJuegos entidad);
    }
}
