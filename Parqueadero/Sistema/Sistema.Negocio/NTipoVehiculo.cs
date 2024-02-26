
using Sistema.Datos;
using Sistema.Entidades;
using System.Data;

namespace Sistema.Negocio
{
    public class NTipoVehiculo
    {
        public static DataTable Listar()
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Listar();
        }

        public static DataTable Seleccionar()
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Seleccionar();
        }

        public static DataTable Buscar(string Valor)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Tipo, string Descripcion, decimal Precio)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();

            string Existe = Datos.Existe(Tipo);
            if (Existe.Equals("1"))
            {
                return "La categoría ya existe";
            }
            else
            {
                TipoVehiculo Obj = new TipoVehiculo();
                Obj.Tipo = Tipo;
                Obj.Descripcion = Descripcion;
                Obj.Precio = Precio;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int Id, string TipoAnt, string Tipo, string Descripcion, decimal precio)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            TipoVehiculo Obj = new TipoVehiculo();

            if (TipoAnt.Equals(Tipo))
            {
                Obj.IdTipoVehiculo = Id;
                Obj.Tipo = Tipo;
                Obj.Descripcion = Descripcion;
                Obj.Precio = precio;
                return Datos.Actualizar(Obj);
            }
            else {
                string Existe = Datos.Existe(Tipo);
                if (Existe.Equals("1"))
                {
                    return "La categoría ya existe";
                }
                else
                {

                    Obj.IdTipoVehiculo = Id;
                    Obj.Tipo = Tipo;
                    Obj.Descripcion = Descripcion;
                    Obj.Precio = precio;
                    return Datos.Actualizar(Obj);
                }
            }
            
        }

        public static string Eliminar(int Id)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Eliminar(Id);
        }

        public static string Activar(int Id)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Activar(Id);
        }

        public static string Desactivar(int Id)
        {
            DTipoVehiculo Datos = new DTipoVehiculo();
            return Datos.Desactivar(Id);
        }
    }
}