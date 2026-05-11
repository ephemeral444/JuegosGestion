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
        public string? Telefono { get; set; }
        public int Edad { get; set; }
        public string? Pais { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? TargetaCredito { get; set; }
        public bool Suscripcion { get; set; }
        public int PuntosTotal { get; set; }
        public int Nivel { get; set; }
        public int RolId { get; set; }
        public int PerifericoId { get; set; }
        public int GestorArchivoId { get; set; }

        public Roles? _rol { get; set; }
        public Perifericos? _periferico { get; set; }
        public GestorArchivos? _gestorArchivo { get; set; }

        public List<Videojuegos>? Videojuegos { get; set; }
        public List<Descargas>? Descargas { get; set; }
        public List<Notificaciones>? Notificaciones { get; set; }
        public List<BibliotecaUsuarios>? BibliotecaUsuarios { get; set; }
        public List<Gestiones>? Gestiones { get; set; }
        public List<ControlJuegos>? ControlJuegos { get; set; }
        public List<SesionesJuegos>? SesionesJuegos { get; set; }
        public List<GuardadoJuegos>? GuardadoJuegos { get; set; }
    }
}
