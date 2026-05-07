using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class GuardadoJuegos : Auditorias
    {
        [Key] public int Id { get; set; }
        public DateOnly FechaGuardado { get; set; }
        public string? Proceso { get; set; }
        public string? Ubicacion { get; set; }
        public string? HorasJugadas { get; set; }
    }
}
