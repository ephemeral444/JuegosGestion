using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Descargas : Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Servidor { get; set; }
        public string? VelocidadMB { get; set; }
        public string? Estado { get; set; }
        public DateOnly FechaInstalacion { get; set; }
    }
}
