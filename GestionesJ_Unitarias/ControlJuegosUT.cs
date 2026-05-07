using GestionJ_biblioteca.Implementaciones;
using GestionJ_biblioteca.Interfaces;

namespace GestionesJ_Unitarias
{
    [TestClass]
    public sealed class ControlJuegosUT
    {
        [TestMethod]
        public void Ejecutar()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = "server=localhost;Integrated Security=True;TrustServerCertificate=true;database=GestionJuegosDB;";
            var lista = conexion.ControlJuegos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception();
        }
    }
}