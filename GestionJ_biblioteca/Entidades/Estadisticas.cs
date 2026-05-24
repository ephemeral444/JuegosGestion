using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Estadisticas
    {
        [Key] public int Id { get; set; }
        public string? TiempoJuego { get; set; }
        public string? JuegosCompletos { get; set; }
        public string? LogrosObtenidos { get; set; }
        public int PromedioFPS { get; set; }
        public int VideojuegoId { get; set; }

        [ForeignKey("VideojuegoId")]
        [JsonIgnore]
        public Videojuegos? _videojuego { get; set; }
    }
}