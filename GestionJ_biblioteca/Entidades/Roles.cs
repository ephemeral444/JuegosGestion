using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Roles 
    {
        [Key] public int Id { get; set; }

        public string? NombreRol { get; set; }

        public List<Usuarios> Usuarios { get; set; }
        public List<Permisos>? Permisos { get; set; }
    }
}
