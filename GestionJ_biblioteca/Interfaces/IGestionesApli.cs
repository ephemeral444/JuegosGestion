using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IGestionesApli
    {
        List<Gestiones> Consultar();
        Gestiones Guardar(Gestiones entidad);
        Gestiones Modificar(Gestiones entidad);
        Gestiones Eliminar(Gestiones entidad);
    }
}
