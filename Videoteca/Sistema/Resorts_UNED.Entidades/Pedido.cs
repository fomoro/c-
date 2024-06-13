using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
