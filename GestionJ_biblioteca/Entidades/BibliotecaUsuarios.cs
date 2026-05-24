using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class BibliotecaUsuarios 
    {
        [Key] public int Id { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string? Favoritos { get; set; }
        public string? HorasJugadas { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [JsonIgnore]
        public Usuarios? _usuario { get; set; }
    }
}

   
