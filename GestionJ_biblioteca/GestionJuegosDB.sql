CREATE DATABASE GestionJuegosDB
GO
USE GestionJuegosDB
GO

-- TABLA DE AUDITORIAS (ISLA)

CREATE TABLE Auditorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreTabla NVARCHAR(100) NULL,
    Operacion NVARCHAR(50) NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Descripcion NVARCHAR(500) NULL
);

-- TABLAS BASE (sin dependencias)

CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(100) NOT NULL
);

CREATE TABLE Plataformas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombrePlataforma NVARCHAR(100) NULL,
    TipoPlataforma NVARCHAR(50) NULL,
    Fabricante NVARCHAR(100) NULL,
    Generacion NVARCHAR(50) NULL,
    Descripcion NVARCHAR(500) NULL,
    FechaLanzamiento DATE NOT NULL
);

CREATE TABLE Perifericos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Video BIT NOT NULL,
    Audio BIT NOT NULL,
    Teclado BIT NOT NULL,
    Raton BIT NOT NULL,
    Mando BIT NOT NULL
);

CREATE TABLE ConfiGenerales (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Idioma NVARCHAR(50) NULL,
    Tema NVARCHAR(50) NULL,
    Autoguardado DATE NOT NULL,
    Version NVARCHAR(50) NULL
);

CREATE TABLE GestorArchivos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreArchivo NVARCHAR(200) NULL,
    TipoArchivo NVARCHAR(50) NULL,
    Tamanio NVARCHAR(50) NULL,
    RutaArchivo NVARCHAR(500) NULL
);

-- TABLAS DE PRIMER NIVEL (dependen de las base)


CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NULL,
    Apellido NVARCHAR(100) NULL,
    Telefono NVARCHAR(20) NULL,
    Edad INT NOT NULL,
    Pais NVARCHAR(100) NULL,
    Correo NVARCHAR(150) NULL,
    Contrasena NVARCHAR(255) NULL,
    TargetaCredito NVARCHAR(20) NULL,
    Suscripcion BIT NOT NULL,
    PuntosTotal INT NOT NULL DEFAULT 0,
    Nivel INT NOT NULL DEFAULT 1,
    RolId INT NOT NULL,
    PerifericoId INT NOT NULL,
    GestorArchivoId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id),
    FOREIGN KEY (PerifericoId) REFERENCES Perifericos(Id),
    FOREIGN KEY (GestorArchivoId) REFERENCES GestorArchivos(Id)
);

CREATE TABLE Emuladores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NULL,
    Version DECIMAL(10,2) NOT NULL,
    Bios NVARCHAR(100) NULL,
    RegionBios NVARCHAR(50) NULL,
    PlataformaId INT NOT NULL,
    FOREIGN KEY (PlataformaId) REFERENCES Plataformas(Id)
);

CREATE TABLE ConfiGraficas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Resolucion NVARCHAR(50) NULL,
    Filtros NVARCHAR(100) NULL,
    Shaders NVARCHAR(100) NULL,
    Vsync BIT NOT NULL,
    ConfiGeneralId INT NOT NULL,
    FOREIGN KEY (ConfiGeneralId) REFERENCES ConfiGenerales(Id)
);

CREATE TABLE ConfigAudios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Latencia NVARCHAR(50) NULL,
    Frecuencia NVARCHAR(50) NULL,
    Volumen INT NOT NULL,
    Modo NVARCHAR(50) NULL,
    ConfiGeneralId INT NOT NULL,
    FOREIGN KEY (ConfiGeneralId) REFERENCES ConfiGenerales(Id)
);

-- TABLAS DE SEGUNDO NIVEL (dependen de primer nivel)

CREATE TABLE Videojuegos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NULL,
    Genero NVARCHAR(100) NULL,
    Formato NVARCHAR(50) NULL,
    Desarrolladora NVARCHAR(100) NULL,
    Region NVARCHAR(50) NULL,
    Tamanio NVARCHAR(50) NULL,
    FechaLanzamiento DATE NOT NULL,
    Licencia BIT NOT NULL,
    Completado BIT NOT NULL,
    UsuarioId INT NOT NULL,
    PlataformaId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (PlataformaId) REFERENCES Plataformas(Id)
);

CREATE TABLE BibliotecaUsuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaRegistro DATE NOT NULL,
    Favoritos NVARCHAR(500) NULL,
    HorasJugadas NVARCHAR(50) NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE Notificaciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NULL,
    Contenido NVARCHAR(500) NULL,
    Mensaje NVARCHAR(1000) NULL,
    TipoNotificacion NVARCHAR(50) NULL,
    Fecha DATE NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE Gestiones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Accion NVARCHAR(200) NULL,
    FechaGestion DATE NOT NULL,
    Resultado BIT NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE ControlJuegos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fps NVARCHAR(50) NULL,
    Controles NVARCHAR(200) NULL,
    Sensibilidad INT NOT NULL,
    Dificultad NVARCHAR(50) NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

-- TABLAS DE TERCER NIVEL (dependen de segundo nivel)

CREATE TABLE Roms (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(200) NULL,
    Genero NVARCHAR(100) NULL,
    Desarrolladora NVARCHAR(100) NULL,
    FechaLanzamiento DATE NOT NULL,
    TamanioArchivo NVARCHAR(50) NULL,
    VideojuegoId INT NOT NULL,
    EmuladorId INT NOT NULL,
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id),
    FOREIGN KEY (EmuladorId) REFERENCES Emuladores(Id)
);

CREATE TABLE Logros (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreLogro NVARCHAR(200) NULL,
    Descripcion NVARCHAR(500) NULL,
    Rareza NVARCHAR(50) NULL,
    EstadoDesbloqueado BIT NOT NULL,
    FechaDesbloqueo DATE NULL,
    Puntos INT NOT NULL DEFAULT 0,
    VideojuegoId INT NOT NULL,
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id)
);

CREATE TABLE Trucos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CodigoTruco INT NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Activo BIT NOT NULL,
    FechaCreacionTruco DATE NOT NULL,
    VideojuegoId INT NOT NULL,
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id)
);

CREATE TABLE SesionesJuegos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombreJuego NVARCHAR(200) NULL,
    Duracion NVARCHAR(50) NULL,
    VideojuegoId INT NOT NULL,
    UsuarioId INT NOT NULL,
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE Estadisticas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TiempoJuego NVARCHAR(50) NULL,
    JuegosCompletos NVARCHAR(50) NULL,
    LogrosObtenidos NVARCHAR(50) NULL,
    PromedioFPS INT NOT NULL,
    VideojuegoId INT NOT NULL,
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id)
);

CREATE TABLE GuardadoJuegos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaGuardado DATE NOT NULL,
    Proceso NVARCHAR(200) NULL,
    Ubicacion NVARCHAR(500) NULL,
    HorasJugadas NVARCHAR(50) NULL,
    UsuarioId INT NOT NULL,
    VideojuegoId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (VideojuegoId) REFERENCES Videojuegos(Id)
);

-- TABLA DE ULTIMO NIVEL (depende de tercer nivel)

CREATE TABLE Descargas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Servidor NVARCHAR(200) NULL,
    VelocidadMB NVARCHAR(50) NULL,
    EstadoDescarga NVARCHAR(50) NULL,
    FechaInstalacion DATE NOT NULL,
    UsuarioId INT NOT NULL,
    RomId INT NOT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (RomId) REFERENCES Roms(Id)
);