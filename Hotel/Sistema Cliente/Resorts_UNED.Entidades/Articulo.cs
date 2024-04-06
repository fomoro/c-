
namespace Resorts_UNED.Entidades
{
    public class Articulo
    {
        public int ID { get; set; }                
        public string Nombre { get; set; }
        public decimal Precio_Venta { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
    }

}
