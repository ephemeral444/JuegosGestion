using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface ITrucosApli
    {
        List<Trucos> Consultar();
        Trucos Guardar(Trucos entidad);
        Trucos Modificar(Trucos entidad);
        Trucos Eliminar(Trucos entidad);
    }
}
