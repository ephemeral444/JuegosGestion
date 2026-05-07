using System;
using System.Collections.Generic;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Roles : Auditorias
    {
        public string NombreRol { get; set; }

        public List<Usuarios> Usuarios { get; set; }
    }
}
