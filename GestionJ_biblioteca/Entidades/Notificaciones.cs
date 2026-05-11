using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Notificaciones 
    {
        [Key] public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Contenido { get; set; }
        public string? Mensaje { get; set; }
        public string? TipoNotificacion { get; set; }
        public DateOnly Fecha { get; set; }

        // FOREIGN KEY
        public int UsuarioId { get; set; }

        // RELACION
        public Usuarios _usuario { get; set; }
    }
}
