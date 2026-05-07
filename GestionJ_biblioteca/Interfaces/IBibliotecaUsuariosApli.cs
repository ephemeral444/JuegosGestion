using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IBibliotecaUsuariosApli
    {
        List<BibliotecaUsuarios> Consultar();
        BibliotecaUsuarios Guardar(BibliotecaUsuarios entidad);
        BibliotecaUsuarios Modificar(BibliotecaUsuarios entidad);
        BibliotecaUsuarios Eliminar(BibliotecaUsuarios entidad);
    }
}
