using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class ConfigAudios 
    {
        [Key] public int Id { get; set; }
        public string? Latencia { get; set; }
        public string? Frecuencia { get; set; }
        public int Volumen { get; set; }
        public string? Modo { get; set; }
    }
}
