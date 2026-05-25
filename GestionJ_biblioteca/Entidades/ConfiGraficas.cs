using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class ConfiGraficas 
    {
        [Key] public int Id { get; set; }
        public string? Resolucion { get; set; }
        public string? Filtros { get; set; }
        public string? Shaders { get; set; }
        public bool Vsync { get; set; }
        public int ConfiGeneralId { get; set; }

        [ForeignKey("ConfiGeneralId")]
        [JsonIgnore]
        public ConfiGenerales? _confiGeneral { get; set; }

    }
}
