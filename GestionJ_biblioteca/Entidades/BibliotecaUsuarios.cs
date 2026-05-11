using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class BibliotecaUsuarios 
    {
        [Key] public int Id { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string? Favoritos { get; set; }
        public string? HorasJugadas { get; set; }
    }
}

   
