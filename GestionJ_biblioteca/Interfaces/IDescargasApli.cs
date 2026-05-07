using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IDescargasApli
    {
        List<Descargas> Consultar();
        Descargas Guardar(Descargas entidad);
        Descargas Modificar(Descargas entidad);
        Descargas Eliminar(Descargas entidad);
    }
}
