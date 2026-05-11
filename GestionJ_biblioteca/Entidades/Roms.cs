using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Roms 
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Plataforma { get; set; }
        public string? Genero { get; set; }
        public string? Desarrolladora { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public string? TamañoArchivo { get; set; }

        // FOREIGN KEYS
        public int VideojuegoId { get; set; }
        public int EmuladorId { get; set; }

        // RELACIONES
        public Videojuegos _videojuego { get; set; }
        public Emuladores _emulador { get; set; }
        public List<Descargas> Descargas { get; set; }
    }
}