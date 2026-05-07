using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IGestorArchivosApli
    {
        List<GestorArchivos> Consultar();
        GestorArchivos Guardar(GestorArchivos entidad);
        GestorArchivos Modificar(GestorArchivos entidad);
        GestorArchivos Eliminar(GestorArchivos entidad);
    }
}
