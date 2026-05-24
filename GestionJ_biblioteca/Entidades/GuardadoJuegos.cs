using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class GuardadoJuegos 
    {
        [Key] public int Id { get; set; }
        public DateOnly FechaGuardado { get; set; }
        public string? Proceso { get; set; }
        public string? Ubicacion { get; set; }
        public string? HorasJugadas { get; set; }
        public int UsuarioId { get; set; }
        public int VideojuegoId { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore]
        public Usuarios? _usuario { get; set; }

        [ForeignKey("VideojuegoId")]
        [JsonIgnore]
        public Videojuegos? _videojuego { get; set; }
    }
}
