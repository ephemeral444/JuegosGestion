using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IConfiGraficApli
    {
        List<ConfiGraficas> Consultar();
        ConfiGraficas Guardar(ConfiGraficas entidad);
        ConfiGraficas Modificar(ConfiGraficas entidad);
        ConfiGraficas Eliminar(ConfiGraficas entidad);
    }
}
