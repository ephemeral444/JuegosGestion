using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionJ_biblioteca.Entidades
{
    public class Perifericos 
    {
        [Key] public int Id { get; set; }  
        public bool Video { get; set; }
        public bool Audio { get; set; }
        public bool Teclado { get; set; }
        public bool Raton { get; set; }
        public bool Mando { get; set; }
    }
}
