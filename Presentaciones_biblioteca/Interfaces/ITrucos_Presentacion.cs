using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface ITrucos_Presentacion
    {
        List<Trucos> Consultar();
        Trucos Guardar(Trucos entidad);
        Trucos Modificar(Trucos entidad);
        Trucos Eliminar(Trucos entidad);
    }
}
