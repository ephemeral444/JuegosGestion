using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface INotificaciones_Presentacion
    {
        List<Notificaciones> Consultar();
        Notificaciones Guardar(Notificaciones entidad);
        Notificaciones Modificar(Notificaciones entidad);
        Notificaciones Eliminar(Notificaciones entidad);
    }
}
