using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Emuladores
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Version { get; set; }
        public string? Plataforma { get; set; }
        public string? Bios { get; set; }
        public string? RegionBios { get; set; }

        public List<Videojuegos>? Videojuegos { get; set; }
    }
}
