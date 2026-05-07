using Microsoft.EntityFrameworkCore;
using GestionJ_biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using GestionJ_biblioteca.Interfaces;

namespace GestionJ_biblioteca.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public DbSet<BibliotecaUsuarios>? BibliotecaUsuarios { get; set; }
        public DbSet<ConfigAudios>? ConfigAudios{ get; set; }
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
        public string? string_conexion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=GestionJuegosDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }

}
