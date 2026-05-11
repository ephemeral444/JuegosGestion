using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Plataformas 
    {
        [Key] public int Id { get; set; }
        public string? NombrePlataforma { get; set; }
        public string? TipoPlataforma { get; set; }
        public string? Fabricante { get; set; }
        public string? Generacion { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly FechaLanzamiento { get; set; }

        public List<Videojuegos> Videojuegos { get; set; }
        public List<Emuladores> Emuladores { get; set; }
    }
}
