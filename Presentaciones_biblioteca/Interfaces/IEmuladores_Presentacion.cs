using GestionJ_biblioteca.Entidades;

namespace Presentaciones_biblioteca.Interfaces
{
    public interface IEmuladores_Presentacion
    {
        List<Emuladores> Consultar();
        Emuladores Guardar(Emuladores entidad);
        Emuladores Modificar(Emuladores entidad);
        Emuladores Eliminar(Emuladores entidad);
    }
}
