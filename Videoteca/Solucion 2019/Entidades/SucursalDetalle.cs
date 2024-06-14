using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SucursalDetalle
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Direccion { get; set; } 
        public string Telefono { get; set; }          
        public int IdEncargado { get; set; } 
        public string NombreEncargado { get; set; }
        public bool Activo { get; set; }
    }
}
