using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PeliculaxSucursal
    {
        public Sucursal Sucursal { get; set; }
        public Pelicula Pelicula { get; set; }
        public int Cantidad { get; set; }
    }

}
