using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Estadisticas
    {
        [Key] public int Id { get; set; }
        public DateOnly TiempoJuego { get; set; }
        public string? JuegosCompletos { get; set; }
        public string? LogrosObtenidos { get; set; }
        public int PromedioFPS { get; set; }

        // FOREIGN KEY
        public int VideojuegoId { get; set; }

        // RELACION
        public Videojuegos _videojuego { get; set; }
    }
}