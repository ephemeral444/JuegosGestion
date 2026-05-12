using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface ILogrosApli
    {
        List<Logros> Consultar();
        Logros Guardar(Logros entidad);
        Logros Modificar(Logros entidad);
        Logros Eliminar(Logros entidad);
        Logros Desbloquear(int usuarioId, Logros entidad);
    }
}
