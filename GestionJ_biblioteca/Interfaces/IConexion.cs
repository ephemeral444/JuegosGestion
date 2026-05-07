using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GestionJ_biblioteca.Entidades;
using GestionJ_biblioteca.Interfaces;
using GestionJ_biblioteca.Implementaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

        public DbSet<BibliotecaUsuarios>? BibliotecaUsuarios { get; set; }
        public DbSet<ConfigAudios>? ConfigAudios { get; set; }
        public DbSet<ConfiGenerales>? ConfiGenerales { get; set; }
        public DbSet<ConfiGraficas>? ConfiGraficas { get; set; }
        public DbSet<ControlJuegos>? ControlJuegos { get; set; }
        public DbSet<Descargas>? Descargas { get; set; }
        public DbSet<Emuladores>? Emuladores { get; set; }
        public DbSet<Estadisticas>? Estadisticas { get; set; }
        public DbSet<Gestiones>? Gestiones { get; set; }
        public DbSet<GestorArchivos>? GestorArchivos { get; set; }
        public DbSet<GuardadoJuegos>? GuardadoJuegos { get; set; }
        public DbSet<Logros>? Logros { get; set; }
        public DbSet<Notificaciones>? Notificaciones { get; set; }
        public DbSet<Perifericos>? Perifericos { get; set; }
        public DbSet<Plataformas>? Plataformas { get; set; }
        public DbSet<Roms>? Roms { get; set; }
        public DbSet<SesionesJuegos>? SesionesJuegos { get; set; }
        public DbSet<Trucos>? Trucos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Videojuegos>? Videojuegos { get; set; }

        int SaveChanges();
        DatabaseFacade Database { get; }
    }
}
