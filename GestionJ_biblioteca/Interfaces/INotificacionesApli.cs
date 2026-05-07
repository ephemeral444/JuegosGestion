using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface INotificacionesApli
    {
        List<Notificaciones> Consultar();
        Notificaciones Guardar(Notificaciones entidad);
        Notificaciones Modificar(Notificaciones entidad);
        Notificaciones Eliminar(Notificaciones entidad);
    }
}
