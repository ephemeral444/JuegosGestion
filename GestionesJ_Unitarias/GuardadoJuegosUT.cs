using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public sealed class GuardadoJuegosUT
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = "server=localhost;Integrated Security=True;TrustServerCertificate=true;database=GestionJuegosDB;";
            var lista = conexion.GuardadoJuegos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception();
        }
    }
}