using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Gestiones 
    {
        [Key] public int Id { get; set; }
        public string? Accion { get; set; }
        public DateOnly FechaGestion { get; set; }
        public bool Resultado { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore]
        public Usuarios? _usuario { get; set; }
    }
}
