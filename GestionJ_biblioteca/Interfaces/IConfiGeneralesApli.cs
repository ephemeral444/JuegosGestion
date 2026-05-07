using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IConfiGeneralesApli
    {
        List<ConfiGenerales> Consultar();
        ConfiGenerales Guardar(ConfiGenerales entidad);
        ConfiGenerales Modificar(ConfiGenerales entidad);
        ConfiGenerales Eliminar(ConfiGenerales entidad);
    }
}
