using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class ControlJuegos 
    {
        [Key] public int Id { get; set; }
        public string? Fps { get; set; }
        public string? Controles { get; set; }
        public int Sensibilidad { get; set; }
        public string? Dificultad { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore] 
        public Usuarios? _usuario { get; set; }
    }
}
