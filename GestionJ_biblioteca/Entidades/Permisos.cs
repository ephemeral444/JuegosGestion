using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Permisos
    {
        [Key] public int Id { get; set; }
        public string? NombrePermiso { get; set; }
        public string? Descripcion { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        [JsonIgnore]
        public Roles? _rol { get; set; }
    }
}