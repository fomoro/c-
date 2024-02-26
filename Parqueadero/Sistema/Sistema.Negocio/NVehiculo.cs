
using Sistema.Datos;
using Sistema.Entidades;
using System.Data;

namespace Sistema.Negocio
{
    public class NVehiculo
    {
        public static DataTable Listar()
        {
            DVehiculo Datos = new DVehiculo();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DVehiculo Datos = new DVehiculo();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(int IdTipoVehiculo, string Placa, string Descripcion)
        {
            DVehiculo Datos = new DVehiculo();

            string Existe = Datos.Existe(Placa);
            if (Existe.Equals("1"))
            {
                return "El artículo ya existe";
            }
            else
            {
                Vehiculo Obj = new Vehiculo();
                Obj.IdTipoVehiculo = IdTipoVehiculo;
                Obj.Placa = Placa;
                Obj.Descripcion = Descripcion;                
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int Id, int IdTipoVehiculo, string Placa, string PlacaAnt, string Descripcion)
        {
            DVehiculo Datos = new DVehiculo();
            Vehiculo Obj = new Vehiculo();

            if (PlacaAnt.Equals(Placa))
            {
                Obj.IdVehiculo = Id;
                Obj.IdTipoVehiculo = IdTipoVehiculo;
                Obj.Placa = Placa;
                Obj.Descripcion = Descripcion;                
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Placa);
                if (Existe.Equals("1"))
                {
                    return "El artículo ya existe";
                }
                else
                {
                    Obj.IdVehiculo = Id;
                    Obj.IdTipoVehiculo = IdTipoVehiculo;
                    Obj.Placa = Placa;
                    Obj.Descripcion = Descripcion;
                    return Datos.Actualizar(Obj);
                }
            }

        }

        public static string Eliminar(int Id)
        {
            DVehiculo Datos = new DVehiculo();
            return Datos.Eliminar(Id);
        }

        public static string Activar(int Id)
        {
            DVehiculo Datos = new DVehiculo();
            return Datos.Activar(Id);
        }

        public static string Desactivar(int Id)
        {
            DVehiculo Datos = new DVehiculo();
            return Datos.Desactivar(Id);
        }
    }
}
