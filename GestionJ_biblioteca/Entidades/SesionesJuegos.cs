using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class SesionesJuegos 
    {
        [Key] public int Id { get; set; }
        public string? NombreJuego { get; set; }
        public string? Plataforma { get; set; }
        public string? Duracion { get; set; }

    }
}
