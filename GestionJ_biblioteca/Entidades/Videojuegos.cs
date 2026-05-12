using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Videojuegos 
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public string? Formato { get; set; }
        public string? Desarrolladora { get; set; }
        public string? Region { get; set; }
        public string? Tamanio { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public bool Licencia { get; set; }
        public bool Completado { get; set; }
        public int UsuarioId { get; set; }
        public int PlataformaId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _usuario { get; set; }

        [ForeignKey("PlataformaId")]
        public Plataformas? _plataforma { get; set; }

        public List<Roms>? Roms { get; set; }
        public List<Logros>? Logros { get; set; }
        public List<Trucos>? Trucos { get; set; }
        public List<SesionesJuegos>? SesionesJuegos { get; set; }
        public List<Estadisticas>? Estadisticas { get; set; }
        public List<GuardadoJuegos>? GuardadoJuegos { get; set; }
    }
}
