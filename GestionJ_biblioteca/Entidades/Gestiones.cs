using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Gestiones : Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Accion { get; set; }
        public DateOnly FechaGestion { get; set; }
        public bool Resultado { get; set; }
    }
}
