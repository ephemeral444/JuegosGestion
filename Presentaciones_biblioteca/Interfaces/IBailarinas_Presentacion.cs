using Bailes_Biblioteca.Entidades;

namespace Bailes_Presentaciones.Interfaces
{
    public interface IBailarinas_Presentacion
    {
        List<Bailarinas> Consultar();
        Bailarinas Guardar(Bailarinas entidad);
        Bailarinas Modificar(Bailarinas entidad);
        Bailarinas Eliminar(Bailarinas entidad);
    }
}
