using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Logros : Auditorias
    {
        [Key] public int Id { get; set; }
        public string? NombreLogro { get; set; }
        public string? Descripcion { get; set; }
        public string? Rareza { get; set; }
        public bool EstadoDesbloqueado { get; set; }
        public DateOnly FechaDesbloqueo { get; set; }
        public int Puntos { get; set; }

    }
}

