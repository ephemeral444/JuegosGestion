using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class GestorArchivos 
    {
        [Key] public int Id { get; set; }
        public string? NombreArchivo { get; set; }
        public string? TipoArchivo { get; set; }
        public string? Tamanio { get; set; }
        public string? RutaArchivo { get; set; }

        [JsonIgnore]
        public List<Usuarios>? Usuarios { get; set; }

    }
}
