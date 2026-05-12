using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Emuladores 
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Version { get; set; }
        public string? Bios { get; set; }
        public string? RegionBios { get; set; }
        public int PlataformaId { get; set; }

        [ForeignKey("PlataformaId")]
        public Plataformas? _plataforma { get; set; }

        public List<Roms>? Roms { get; set; }
    }
}
