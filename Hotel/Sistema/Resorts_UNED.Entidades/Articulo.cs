using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Entidades
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int IdCategoria { get; set; }
    }

}
