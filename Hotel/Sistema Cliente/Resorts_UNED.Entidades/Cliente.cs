using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Entidades
{
    public class Cliente
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }

        public List<Pedido> pedidos { get; set; }

        public Cliente()
        {
            pedidos = new List<Pedido>();
        }
    }

}
