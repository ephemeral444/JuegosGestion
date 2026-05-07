using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IControlJuegosApli
    {
        List<ControlJuegos> Consultar();
        ControlJuegos Guardar(ControlJuegos entidad);
        ControlJuegos Modificar(ControlJuegos entidad);
        ControlJuegos Eliminar(ControlJuegos entidad);
    }
}
