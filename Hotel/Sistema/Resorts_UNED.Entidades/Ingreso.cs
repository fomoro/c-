using System;
using System.Data;

namespace Resorts_UNED.Entidades
{
    public class Ingreso
    {
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public string Telefono { get; set; }
        public DataTable Detalles { get; set; }

    }
}
