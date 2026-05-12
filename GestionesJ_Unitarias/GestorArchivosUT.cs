using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public sealed class GestorArchivosUT
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = "server=localhost;Integrated Security=True;TrustServerCertificate=true;database=GestionJuegosDB;";
            var lista = conexion.GestorArchivos!.ToList();
            Assert.IsNotNull(lista);
        }
    }
}