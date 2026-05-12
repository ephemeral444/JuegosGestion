using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Descargas 
    {
        [Key] public int Id { get; set; }
        public string? Servidor { get; set; }
        public string? VelocidadMB { get; set; }
        public string? EstadoDescarga { get; set; }
        public DateOnly FechaInstalacion { get; set; }
        public int UsuarioId { get; set; }
        public int RomId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _usuario { get; set; }

        [ForeignKey("RomId")]
        public Roms? _rom { get; set; }
    }
}
