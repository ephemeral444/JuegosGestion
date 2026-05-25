using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class ConfiGenerales
    {
        [Key] public int Id { get; set; }
        public string? Idioma { get; set; }
        public string? Tema { get; set; }
        public DateOnly Autoguardado {  get; set; }
        public string? Version { get; set; }

        [JsonIgnore]
        public List<ConfiGraficas>? ConfiGraficas { get; set; }
        [JsonIgnore]
        public List<ConfigAudios>? ConfigAudios { get; set; }


    }
}
