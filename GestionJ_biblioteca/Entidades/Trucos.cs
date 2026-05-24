using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Trucos 
    {
        [Key] public int Id { get; set; }
        public int CodigoTruco { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateOnly FechaCreacionTruco { get; set; }
        public int VideojuegoId { get; set; }

        [ForeignKey("VideojuegoId")]
        [JsonIgnore]
        public Videojuegos? _videojuego { get; set; }
    }
}
