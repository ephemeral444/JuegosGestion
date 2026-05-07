using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IVideojuegosApli
    {
        List<Videojuegos> Consultar();
        Videojuegos Guardar(Videojuegos entidad);
        Videojuegos Modificar(Videojuegos entidad);
        Videojuegos Eliminar(Videojuegos entidad);
    }
}
