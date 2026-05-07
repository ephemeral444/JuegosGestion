using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface ISesionesJuegosApli
    {
        List<SesionesJuegos> Consultar();
        SesionesJuegos Guardar(SesionesJuegos entidad);
        SesionesJuegos Modificar(SesionesJuegos entidad);
        SesionesJuegos Eliminar(SesionesJuegos entidad);
    }
}
