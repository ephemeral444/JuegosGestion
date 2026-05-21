using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IControlJuegos_Presentacion
    {
        List<ControlJuegos> Consultar();
        ControlJuegos Guardar(ControlJuegos entidad);
        ControlJuegos Modificar(ControlJuegos entidad);
        ControlJuegos Eliminar(ControlJuegos entidad);
    }
}
