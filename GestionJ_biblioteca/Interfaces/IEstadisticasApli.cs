using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Implementaciones;


namespace GestionJ_biblioteca.Interfaces
{
    public interface IEstadisticasApli
    {
        List<Estadisticas> Consultar();
        Estadisticas Guardar(Estadisticas entidad);
        Estadisticas Modificar(Estadisticas entidad);
        Estadisticas Eliminar(Estadisticas entidad);
    }
}
