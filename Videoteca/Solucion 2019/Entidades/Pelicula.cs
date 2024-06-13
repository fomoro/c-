using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public CategoriaPelicula Categoria { get; set; }
        public int AnoLanzamiento { get; set; }
        public string Idioma { get; set; }
    }

}
