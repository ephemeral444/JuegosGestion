using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IPerifericosApli
    {
        List<Perifericos> Consultar();
        Perifericos Guardar(Perifericos entidad);
        Perifericos Modificar(Perifericos entidad);
        Perifericos Eliminar(Perifericos entidad);
    }
}
