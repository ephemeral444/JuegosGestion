using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Trucos : Auditorias
    {
        [Key] public int Id { get; set; }
        public int CodigoTruco { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateOnly FechaCreacion { get; set; }
    }
}
