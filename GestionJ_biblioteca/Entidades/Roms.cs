using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Roms 
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? Desarrolladora { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public string? TamanioArchivo { get; set; }
        public int VideojuegoId { get; set; }
        public int EmuladorId { get; set; }

        [ForeignKey("VideojuegoId")]
        [JsonIgnore]
        public Videojuegos? _videojuego { get; set; }

        [ForeignKey("EmuladorId")]
        [JsonIgnore]
        public Emuladores? _emulador { get; set; }

        [JsonIgnore]
        public List<Descargas>? Descargas { get; set; }
    }
}