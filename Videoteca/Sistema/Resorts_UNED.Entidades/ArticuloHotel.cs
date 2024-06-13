using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Entidades
{
    public class ArticuloHotel
    {
        public int IdAsignacion { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int IdHotel { get; set; }
        public int IdArticulo { get; set; }
    }
}
