using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IAuditoriasApli
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Eliminar(Auditorias entidad);
    }
}
