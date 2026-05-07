using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IUsuariosApli
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        Usuarios Eliminar(Usuarios entidad);
    }
}
