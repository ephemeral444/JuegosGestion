using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Usuarios 
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public string? Pais { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int TargetaCredito { get; set; }
        public bool Suscripcion { get; set; }

        // FOREIGN KEY
        public int RolId { get; set; }

        // RELACION
        public Roles _rol { get; set; }
        public List<Videojuegos> Videojuegos { get; set; }
        public List<Descargas> Descargas { get; set; }
        public List<Notificaciones> Notificaciones { get; set; }
    }
}
