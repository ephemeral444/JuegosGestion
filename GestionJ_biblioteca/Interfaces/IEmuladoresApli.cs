using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IEmuladoresApli
    {
        List<Emuladores> Consultar();
        Emuladores Guardar(Emuladores entidad);
        Emuladores Modificar(Emuladores entidad);
        Emuladores Eliminar(Emuladores entidad);
    }
}
