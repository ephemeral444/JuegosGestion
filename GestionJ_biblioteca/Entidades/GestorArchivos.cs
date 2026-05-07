using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class GestorArchivos : Auditorias
    {
        [Key] public int Id { get; set; }
        public string? NombreArchivo { get; set; }
        public string? TipoArchivo { get; set; }
        public string? Tamaño { get; set; }
        public string? RutaArchivo { get; set; }
    }
}
