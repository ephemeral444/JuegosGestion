using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? NombreTabla { get; set; }
        public string? Operacion { get; set; }
        public string? Descripcion { get; set; }
    }
}
