using System;
using System.Collections.Generic;

namespace Server_Con_Objetos
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Descripcion { get; set; }   
    }
}
