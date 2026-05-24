using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class SesionesJuegos 
    {
        [Key] public int Id { get; set; }
        public string? NombreJuego { get; set; }
        public string? Duracion { get; set; }
        public int VideojuegoId { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("VideojuegoId")]
        [JsonIgnore]
        public Videojuegos? _videojuego { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore]
        public Usuarios? _usuario { get; set; }

    }
}
