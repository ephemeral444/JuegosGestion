using GestionJ_biblioteca.Entidades;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentaciones_biblioteca.Implementaciones;
using Presentaciones_biblioteca.Interfaces;

namespace GestionJ_Razor.Pages
{
    public class ReporteModel : PageModel
    {
        private IVideojuegos_Presentacion? iVideojuegos;
        private ILogros_Presentacion? iLogros;
        private IEstadisticas_Presentacion? iEstadisticas;
        private IEmuladores_Presentacion? iEmuladores;
        private IUsuarios_Presentacion? iUsuarios;
        private ISesionesJuegos_Presentacion? iSesiones;

        public ReporteModel()
        {
            iVideojuegos = new Videojuegos_Presentacion();
            iLogros = new Logros_Presentacion();
            iEstadisticas = new Estadisticas_Presentacion();
            iEmuladores = new Emuladores_Presentacion();
            iUsuarios = new Usuarios_Presentacion();
            iSesiones = new SesionesJuegos_Presentacion();
        }

        public void OnGet() { }

        public IActionResult OnPostDescargar()
        {
            var rolId = HttpContext.Session.GetString("RolId");
            var nombreUsuario = HttpContext.Session.GetString("UsuarioNombre") ?? "Usuario";
            int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int usuarioId);

            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);

            // Colores
            var rojo = new DeviceRgb(192, 57, 43);
            var grisOscuro = new DeviceRgb(30, 30, 50);
            var blanco = ColorConstants.WHITE;

            // Titulo
            doc.Add(new Paragraph("⚡ ELEMENTEL GAMES")
                .SetFontSize(22)
                .SetBold()
                .SetFontColor(rojo)
                .SetTextAlignment(TextAlignment.CENTER));

            if (rolId == "1")
            {
                // REPORTE ADMIN
                doc.Add(new Paragraph("REPORTE GENERAL DE LA PLATAFORMA")
                    .SetFontSize(14)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(5));

                doc.Add(new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20));

                // Usuarios
                var usuarios = iUsuarios!.Consultar();
                doc.Add(new Paragraph("👥 USUARIOS REGISTRADOS")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(15).SetMarginBottom(8));

                var tablaUsuarios = new Table(UnitValue.CreatePercentArray(new float[] { 3, 3, 2, 2 }))
                    .UseAllAvailableWidth();
                tablaUsuarios.AddHeaderCell(new Cell().Add(new Paragraph("Nombre").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaUsuarios.AddHeaderCell(new Cell().Add(new Paragraph("Correo").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaUsuarios.AddHeaderCell(new Cell().Add(new Paragraph("Nivel").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaUsuarios.AddHeaderCell(new Cell().Add(new Paragraph("Puntos").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                foreach (var u in usuarios)
                {
                    tablaUsuarios.AddCell(new Cell().Add(new Paragraph($"{u.Nombre} {u.Apellido}")));
                    tablaUsuarios.AddCell(new Cell().Add(new Paragraph(u.Correo ?? "")));
                    tablaUsuarios.AddCell(new Cell().Add(new Paragraph(u.Nivel.ToString())));
                    tablaUsuarios.AddCell(new Cell().Add(new Paragraph(u.PuntosTotal.ToString())));
                }
                doc.Add(tablaUsuarios);

                // Videojuegos
                var juegos = iVideojuegos!.Consultar();
                doc.Add(new Paragraph("🕹️ VIDEOJUEGOS EN LA PLATAFORMA")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(20).SetMarginBottom(8));

                var tablaJuegos = new Table(UnitValue.CreatePercentArray(new float[] { 4, 2, 2, 2 }))
                    .UseAllAvailableWidth();
                tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Titulo").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Genero").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Region").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Completado").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                foreach (var j in juegos)
                {
                    tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Titulo ?? "")));
                    tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Genero ?? "")));
                    tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Region ?? "")));
                    tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Completado ? "Sí" : "No")));
                }
                doc.Add(tablaJuegos);

                // Emuladores
                var emuladores = iEmuladores!.Consultar();
                doc.Add(new Paragraph("💻 EMULADORES")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(20).SetMarginBottom(8));

                var tablaEmu = new Table(UnitValue.CreatePercentArray(new float[] { 3, 2, 2, 3 }))
                    .UseAllAvailableWidth();
                tablaEmu.AddHeaderCell(new Cell().Add(new Paragraph("Nombre").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaEmu.AddHeaderCell(new Cell().Add(new Paragraph("Version").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaEmu.AddHeaderCell(new Cell().Add(new Paragraph("Region").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                tablaEmu.AddHeaderCell(new Cell().Add(new Paragraph("BIOS").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                foreach (var e in emuladores)
                {
                    tablaEmu.AddCell(new Cell().Add(new Paragraph(e.Nombre ?? "")));
                    tablaEmu.AddCell(new Cell().Add(new Paragraph(e.Version.ToString())));
                    tablaEmu.AddCell(new Cell().Add(new Paragraph(e.RegionBios ?? "")));
                    tablaEmu.AddCell(new Cell().Add(new Paragraph(e.Bios ?? "")));
                }
                doc.Add(tablaEmu);
            }
            else
            {
                // REPORTE USUARIO
                doc.Add(new Paragraph($"REPORTE PERSONAL — {nombreUsuario.ToUpper()}")
                    .SetFontSize(14).SetBold()
                    .SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(5));

                doc.Add(new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}")
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));

                // Mis juegos
                var todosJuegos = iVideojuegos!.Consultar();
                var misJuegos = todosJuegos.Where(v => v.UsuarioId == usuarioId).ToList();

                doc.Add(new Paragraph("🕹️ MIS JUEGOS")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(15).SetMarginBottom(8));

                if (misJuegos.Any())
                {
                    var tablaJuegos = new Table(UnitValue.CreatePercentArray(new float[] { 4, 2, 2, 2 }))
                        .UseAllAvailableWidth();
                    tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Titulo").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Genero").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Región").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaJuegos.AddHeaderCell(new Cell().Add(new Paragraph("Completado").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    foreach (var j in misJuegos)
                    {
                        tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Titulo ?? "")));
                        tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Genero ?? "")));
                        tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Region ?? "")));
                        tablaJuegos.AddCell(new Cell().Add(new Paragraph(j.Completado ? "Sí" : "No")));
                    }
                    doc.Add(tablaJuegos);
                }

                // Mis logros
                var todosLogros = iLogros!.Consultar();
                var misLogros = todosLogros.Where(l =>
                    l.EstadoDesbloqueado &&
                    misJuegos.Any(j => j.Id == l.VideojuegoId)).ToList();

                doc.Add(new Paragraph("🏆 MIS LOGROS")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(20).SetMarginBottom(8));

                doc.Add(new Paragraph($"Total: {misLogros.Count} logros | Puntos: {misLogros.Sum(l => l.Puntos)} pts")
                    .SetFontSize(10).SetMarginBottom(10));

                if (misLogros.Any())
                {
                    var tablaLogros = new Table(UnitValue.CreatePercentArray(new float[] { 4, 2, 2 }))
                        .UseAllAvailableWidth();
                    tablaLogros.AddHeaderCell(new Cell().Add(new Paragraph("Logro").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaLogros.AddHeaderCell(new Cell().Add(new Paragraph("Rareza").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaLogros.AddHeaderCell(new Cell().Add(new Paragraph("Puntos").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    foreach (var l in misLogros)
                    {
                        tablaLogros.AddCell(new Cell().Add(new Paragraph(l.NombreLogro ?? "")));
                        tablaLogros.AddCell(new Cell().Add(new Paragraph(l.Rareza ?? "")));
                        tablaLogros.AddCell(new Cell().Add(new Paragraph(l.Puntos.ToString())));
                    }
                    doc.Add(tablaLogros);
                }

                // Estadisticas
                var todasStats = iEstadisticas!.Consultar();
                var misStats = todasStats.Where(e =>
                    misJuegos.Any(j => j.Id == e.VideojuegoId)).ToList();

                doc.Add(new Paragraph("📊 ESTADÍSTICAS")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(20).SetMarginBottom(8));

                if (misStats.Any())
                {
                    var tablaStats = new Table(UnitValue.CreatePercentArray(new float[] { 3, 2, 2, 2, 2 }))
                        .UseAllAvailableWidth();
                    tablaStats.AddHeaderCell(new Cell().Add(new Paragraph("Juego").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaStats.AddHeaderCell(new Cell().Add(new Paragraph("Tiempo").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaStats.AddHeaderCell(new Cell().Add(new Paragraph("Completados").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaStats.AddHeaderCell(new Cell().Add(new Paragraph("Logros").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaStats.AddHeaderCell(new Cell().Add(new Paragraph("FPS").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    foreach (var s in misStats)
                    {
                        var juego = misJuegos.FirstOrDefault(j => j.Id == s.VideojuegoId);
                        tablaStats.AddCell(new Cell().Add(new Paragraph(juego?.Titulo ?? "")));
                        tablaStats.AddCell(new Cell().Add(new Paragraph(s.TiempoJuego ?? "")));
                        tablaStats.AddCell(new Cell().Add(new Paragraph(s.JuegosCompletos ?? "")));
                        tablaStats.AddCell(new Cell().Add(new Paragraph(s.LogrosObtenidos ?? "")));
                        tablaStats.AddCell(new Cell().Add(new Paragraph(s.PromedioFPS.ToString())));
                    }
                    doc.Add(tablaStats);
                }

                // Sesiones
                var todasSesiones = iSesiones!.Consultar();
                var misSesiones = todasSesiones.Where(s => s.UsuarioId == usuarioId).ToList();

                doc.Add(new Paragraph("⏱️ SESIONES DE JUEGO")
                    .SetFontSize(13).SetBold().SetFontColor(rojo).SetMarginTop(20).SetMarginBottom(8));

                if (misSesiones.Any())
                {
                    var tablaSesiones = new Table(UnitValue.CreatePercentArray(new float[] { 5, 5 }))
                        .UseAllAvailableWidth();
                    tablaSesiones.AddHeaderCell(new Cell().Add(new Paragraph("Juego").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    tablaSesiones.AddHeaderCell(new Cell().Add(new Paragraph("Duración").SetBold()).SetBackgroundColor(grisOscuro).SetFontColor(blanco));
                    foreach (var s in misSesiones)
                    {
                        tablaSesiones.AddCell(new Cell().Add(new Paragraph(s.NombreJuego ?? "")));
                        tablaSesiones.AddCell(new Cell().Add(new Paragraph(s.Duracion ?? "")));
                    }
                    doc.Add(tablaSesiones);
                }
            }

            doc.Close();

            var nombreArchivo = rolId == "1"
                ? "Reporte_General_ElementelGames.pdf"
                : $"Reporte_{nombreUsuario.Replace(" ", "_")}.pdf";

            return File(stream.ToArray(), "application/pdf", nombreArchivo);
        }
    }
}