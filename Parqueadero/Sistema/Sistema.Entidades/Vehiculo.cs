namespace Sistema.Entidades
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
    }
}
