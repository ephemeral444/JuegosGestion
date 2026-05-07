using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Videojuegos : Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public string? Formato { get; set; }
        public string? Desarrolladora { get; set; }
        public string? Plataforma { get; set; }
        public string? Region { get; set; }
        public string? Tamaño { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public bool Licencia { get; set; }
        public bool Completado { get; set; }

        public List<Roms>? Roms { get; set; }
        public List<Trucos>? Trucos { get; set; }
        public List<Emuladores>? Emuladores { get; set; }
        public List<Logros>? Logros { get; set; }
    }
}
