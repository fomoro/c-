using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PeliculaDetalle
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int AnoLanzamiento { get; set; }
        public string Idioma { get; set; }
        public bool Estado { get; set; }        
    }
}

