using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionJ_biblioteca.Entidades
{
    public class Permisos
    {
        [Key] public int Id { get; set; }
        public string? NombrePermiso { get; set; }
        public string? Descripcion { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Roles? _rol { get; set; }
    }
}