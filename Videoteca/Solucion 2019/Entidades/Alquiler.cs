using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alquiler
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public PeliculaxSucursal PeliculaxSucursal { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
    }
}
