using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IRomsApli
    {
        List<Roms> Consultar();
        Roms Guardar(Roms entidad);
        Roms Modificar(Roms entidad);
        Roms Eliminar(Roms entidad);
    }
}
