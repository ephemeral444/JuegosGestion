using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Nucleos
{
    public static class Configuraciones
    {
        public static string obtener(string clave)
        {
            if (clave == "string_conexion")
            {
                return "Server=localhost;Database=GestionJuegosDB;Trusted_Connection=True;TrustServerCertificate=True;";
            }

            throw new Exception("Clave no encontrada");
        }
    }

}
