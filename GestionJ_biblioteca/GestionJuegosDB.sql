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

CREATE TABLE Permisos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NombrePermiso NVARCHAR(100) NULL,
    Descripcion NVARCHAR(300) NULL,
    RolId INT NOT NULL,
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
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

-- AUDITORIAS
INSERT INTO Auditorias (NombreTabla, Operacion, Fecha, Descripcion) VALUES
('Roles', 'INSERT', GETDATE(), 'Insercion inicial'),
('Usuarios', 'INSERT', GETDATE(), 'Insercion inicial'),
('Videojuegos', 'INSERT', GETDATE(), 'Insercion inicial');

-- ROLES
INSERT INTO Roles (NombreRol) VALUES
('Administrador'),
('Cliente'),
('Moderador');

-- PLATAFORMAS
INSERT INTO Plataformas (NombrePlataforma, TipoPlataforma, Fabricante, Generacion, Descripcion, FechaLanzamiento) VALUES
('PlayStation 2', 'Consola', 'Sony', '6', 'Consola de sobremesa de Sony', '2000-03-04'),
('Nintendo 64', 'Consola', 'Nintendo', '5', 'Consola de 64 bits de Nintendo', '1996-06-23'),
('Game Boy Advance', 'Portatil', 'Nintendo', '6', 'Consola portatil de Nintendo', '2001-03-21'),
('Sega Genesis', 'Consola', 'Sega', '4', 'Consola de 16 bits de Sega', '1988-10-29'),
('Super Nintendo', 'Consola', 'Nintendo', '4', 'Consola de 16 bits de Nintendo', '1990-11-21');

-- PERIFERICOS
INSERT INTO Perifericos (Video, Audio, Teclado, Raton, Mando) VALUES
(1, 1, 1, 1, 0),
(1, 1, 0, 0, 1),
(1, 0, 1, 0, 1);

-- CONFIGENERALES
INSERT INTO ConfiGenerales (Idioma, Tema, Autoguardado, Version) VALUES
('ES', 'Oscuro', '2024-01-01', '1.0.0'),
('EN', 'Claro', '2024-01-01', '1.2.0'),
('ES', 'Oscuro', '2024-01-01', '2.0.0');

-- GESTORARCHIVOS
INSERT INTO GestorArchivos (NombreArchivo, TipoArchivo, Tamanio, RutaArchivo) VALUES
('sonic.iso', 'ISO', '700MB', '/roms/sega/sonic.iso'),
('zelda.z64', 'Z64', '32MB', '/roms/n64/zelda.z64'),
('mario.smc', 'SMC', '512KB', '/roms/snes/mario.smc');

-- PERMISOS
INSERT INTO Permisos (NombrePermiso, Descripcion, RolId) VALUES
('Ver_Videojuegos', 'Permite ver el catalogo de videojuegos', 1),
('Editar_Videojuegos', 'Permite editar videojuegos', 1),
('Descargar_Roms', 'Permite descargar roms', 2),
('Ver_Estadisticas', 'Permite ver estadisticas', 2),
('Moderar_Contenido', 'Permite moderar contenido', 3);

-- USUARIOS
INSERT INTO Usuarios (Nombre, Apellido, Telefono, Edad, Pais, Correo, Contrasena, TargetaCredito, Suscripcion, PuntosTotal, Nivel, RolId, PerifericoId, GestorArchivoId) VALUES
('Carlos', 'Ramirez', '3001234567', 25, 'Colombia', 'carlos@gmail.com', '1234', '4111111111111111', 1, 1500, 2, 1, 1, 1),
('Ana', 'Lopez', '3109876543', 22, 'Colombia', 'ana@gmail.com', '1234', '4222222222222222', 0, 250, 1, 2, 2, 2),
('Pedro', 'Martinez', '3201112233', 30, 'Mexico', 'pedro@gmail.com', '1234', '4333333333333333', 1, 5000, 1, 2, 3, 3);

-- EMULADORES
INSERT INTO Emuladores (Nombre, Version, Bios, RegionBios, PlataformaId) VALUES
('PCSX2', 1.60, 'scph10000.bin', 'NTSC-J', 1),
('Project64', 2.40, 'none', 'NTSC-U', 2),
('VisualBoyAdvance', 1.80, 'gba_bios.bin', 'Universal', 3),
('Gens', 2.14, 'bios_CD_U.bin', 'NTSC-U', 4),
('ZSNES', 1.51, 'none', 'Universal', 5);

-- CONFIGRAFICAS
INSERT INTO ConfiGraficas (Resolucion, Filtros, Shaders, Vsync, ConfiGeneralId) VALUES
('1080p', 'Ninguno', 'Default', 1, 1),
('720p', 'Bilinear', 'FXAA', 0, 2),
('4K', 'Anisotropico', 'CRT', 1, 3);

-- CONFIGAUDIOS
INSERT INTO ConfigAudios (Latencia, Frecuencia, Volumen, Modo, ConfiGeneralId) VALUES
('50ms', '44100Hz', 80, 'Estereo', 1),
('30ms', '48000Hz', 100, 'Surround', 2),
('70ms', '44100Hz', 60, 'Mono', 3);

-- VIDEOJUEGOS
INSERT INTO Videojuegos (Titulo, Genero, Formato, Desarrolladora, Region, Tamanio, FechaLanzamiento, Licencia, Completado, UsuarioId, PlataformaId) VALUES
('God of War II', 'Accion', 'ISO', 'Santa Monica', 'NTSC-U', '4.7GB', '2007-03-13', 0, 1, 1, 1),
('The Legend of Zelda OOT', 'Aventura', 'Z64', 'Nintendo', 'NTSC-U', '32MB', '1998-11-21', 0, 0, 2, 2),
('Pokemon Emerald', 'RPG', 'GBA', 'Game Freak', 'Universal', '16MB', '2004-09-16', 0, 1, 3, 3),
('Sonic the Hedgehog 2', 'Plataformas', 'BIN', 'Sega', 'NTSC-U', '1MB', '1992-11-24', 0, 0, 1, 4),
('Super Mario World', 'Plataformas', 'SMC', 'Nintendo', 'NTSC-U', '512KB', '1990-11-21', 0, 1, 2, 5);

-- BIBLIOTECAUSUARIOS
INSERT INTO BibliotecaUsuarios (FechaRegistro, Favoritos, HorasJugadas, UsuarioId) VALUES
('2024-01-15', 'God of War II', '120', 1),
('2024-02-20', 'Zelda OOT', '80', 2),
('2024-03-10', 'Pokemon Emerald', '200', 3);

-- NOTIFICACIONES
INSERT INTO Notificaciones (Titulo, Contenido, Mensaje, TipoNotificacion, Fecha, UsuarioId) VALUES
('Logro desbloqueado', 'Has desbloqueado un logro', 'Felicitaciones por tu logro Platino', 'Logro', '2024-01-20', 1),
('Nueva descarga', 'Tu descarga esta lista', 'Zelda OOT descargado exitosamente', 'Descarga', '2024-02-25', 2),
('Subiste de nivel', 'Nuevo nivel alcanzado', 'Has alcanzado el nivel 2', 'Nivel', '2024-03-15', 1);

-- GESTIONES
INSERT INTO Gestiones (Accion, FechaGestion, Resultado, UsuarioId) VALUES
('Actualizar perfil', '2024-01-10', 1, 1),
('Cambiar contrasena', '2024-02-15', 1, 2),
('Solicitar suscripcion', '2024-03-05', 1, 3);

-- CONTROLJUEGOS
INSERT INTO ControlJuegos (Fps, Controles, Sensibilidad, Dificultad, UsuarioId) VALUES
('60', 'Mando', 5, 'Normal', 1),
('30', 'Teclado', 3, 'Facil', 2),
('60', 'Mando', 8, 'Dificil', 3);

-- ROMS
INSERT INTO Roms (Nombre, Genero, Desarrolladora, FechaLanzamiento, TamanioArchivo, VideojuegoId, EmuladorId) VALUES
('God of War II NTSC', 'Accion', 'Santa Monica', '2007-03-13', '4.7GB', 1, 1),
('Zelda OOT NTSC', 'Aventura', 'Nintendo', '1998-11-21', '32MB', 2, 2),
('Pokemon Emerald EUR', 'RPG', 'Game Freak', '2004-09-16', '16MB', 3, 3),
('Sonic 2 NTSC', 'Plataformas', 'Sega', '1992-11-24', '1MB', 4, 4),
('Super Mario World NTSC', 'Plataformas', 'Nintendo', '1990-11-21', '512KB', 5, 5);

-- LOGROS
INSERT INTO Logros (NombreLogro, Descripcion, Rareza, EstadoDesbloqueado, FechaDesbloqueo, Puntos, VideojuegoId) VALUES
('Dios de la Guerra', 'Completa el juego en modo dificil', 'Platino', 1, '2024-01-18', 1000, 1),
('Heroe de Hyrule', 'Derrota a Ganon', 'Oro', 0, NULL, 500, 2),
('Maestro Pokemon', 'Captura los 386 Pokemon', 'Platino', 1, '2024-03-12', 1000, 3),
('Velocista', 'Completa el primer nivel en menos de 30s', 'Bronce', 1, '2024-01-05', 100, 4),
('Mundo Completado', 'Completa todos los mundos', 'Plata', 0, NULL, 250, 5);

-- TRUCOS
INSERT INTO Trucos (CodigoTruco, Descripcion, Activo, FechaCreacionTruco, VideojuegoId) VALUES
(1234, 'Vida infinita', 1, '2024-01-01', 1),
(5678, 'Municion infinita', 1, '2024-01-01', 2),
(9012, 'Todos los items', 0, '2024-01-01', 3);

--SESIONESJUEGOS
INSERT INTO SesionesJuegos (NombreJuego, Duracion, VideojuegoId, UsuarioId) VALUES
('God of War II', '3h 20min', 1, 1),
('Zelda OOT', '2h 45min', 2, 2),
('Pokemon Emerald', '4h 10min', 3, 3);

-- ESTADISTICAS
INSERT INTO Estadisticas (TiempoJuego, JuegosCompletos, LogrosObtenidos, PromedioFPS, VideojuegoId) VALUES
('120h', '1', '15', 60, 1),
('80h', '0', '8', 30, 2),
('200h', '1', '20', 60, 3);

-- GUARDADOJUEGOS
INSERT INTO GuardadoJuegos (FechaGuardado, Proceso, Ubicacion, HorasJugadas, UsuarioId, VideojuegoId) VALUES
('2024-01-15', 'Capitulo 5', '/saves/gow2/slot1.sav', '50h', 1, 1),
('2024-02-20', 'Templo del Agua', '/saves/zelda/slot1.sav', '30h', 2, 2),
('2024-03-10', 'Liga Pokemon', '/saves/pokemon/slot1.sav', '100h', 3, 3);

-- DESCARGAS
INSERT INTO Descargas (Servidor, VelocidadMB, EstadoDescarga, FechaInstalacion, UsuarioId, RomId) VALUES
('Server-CO-1', '10MB/s', 'Completada', '2024-01-10', 1, 1),
('Server-CO-2', '5MB/s', 'Completada', '2024-02-15', 2, 2),
('Server-MX-1', '8MB/s', 'Activa', '2024-03-05', 3, 3);

