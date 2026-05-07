using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IGuardadoJuegosApli
    {
        List<GuardadoJuegos> Consultar();
        GuardadoJuegos Guardar(GuardadoJuegos entidad);
        GuardadoJuegos Modificar(GuardadoJuegos entidad);
        GuardadoJuegos Eliminar(GuardadoJuegos entidad);
    }
}
