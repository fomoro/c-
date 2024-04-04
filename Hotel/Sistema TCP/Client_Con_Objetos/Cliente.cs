using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Con_Objetos
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Articulo> Articulos { get; set; }

        public Cliente()
        {
            Articulos = new List<Articulo>();
        }
    }

}
