using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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

        [ForeignKey("RolId")]
        [JsonIgnore]
        public Roles? _rol { get; set; }

        [ForeignKey("PerifericoId")]
        [JsonIgnore]
        public Perifericos? _periferico { get; set; }

        [ForeignKey("GestorArchivoId")]
        [JsonIgnore]
        public GestorArchivos? _gestorArchivo { get; set; }

        [JsonIgnore]
        public List<Videojuegos>? Videojuegos { get; set; }
        [JsonIgnore]
        public List<Descargas>? Descargas { get; set; }
        [JsonIgnore]
        public List<Notificaciones>? Notificaciones { get; set; }
        [JsonIgnore]
        public List<BibliotecaUsuarios>? BibliotecaUsuarios { get; set; }
        [JsonIgnore]
        public List<Gestiones>? Gestiones { get; set; }
        [JsonIgnore]
        public List<ControlJuegos>? ControlJuegos { get; set; }
        [JsonIgnore]
        public List<SesionesJuegos>? SesionesJuegos { get; set; }
        [JsonIgnore]
        public List<GuardadoJuegos>? GuardadoJuegos { get; set; }
    }
}
