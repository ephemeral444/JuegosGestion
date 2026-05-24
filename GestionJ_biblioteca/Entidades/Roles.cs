using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionJ_biblioteca.Entidades
{
    public class Roles 
    {
        [Key] public int Id { get; set; }

        public string? NombreRol { get; set; }

        [JsonIgnore]
        public List<Usuarios>? Usuarios { get; set; }
        [JsonIgnore]
        public List<Permisos>? Permisos { get; set; }
    }
}
