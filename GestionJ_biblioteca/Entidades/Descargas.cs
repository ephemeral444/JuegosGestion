using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Descargas 
    {
        [Key] public int Id { get; set; }
        public string? Servidor { get; set; }
        public string? VelocidadMB { get; set; }
        public string? Estado { get; set; }
        public DateOnly FechaInstalacion { get; set; }

        // FOREIGN KEYS
        public int UsuarioId { get; set; }
        public int RomId { get; set; }

        // RELACIONES
        public Usuarios _usuario { get; set; }
        public Roms _rom { get; set; }
    }
}
