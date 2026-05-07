using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IPlataformasApli
    {
        List<Plataformas> Consultar();
        Plataformas Guardar(Plataformas entidad);
        Plataformas Modificar(Plataformas entidad);
        Plataformas Eliminar(Plataformas entidad);
    }
}
