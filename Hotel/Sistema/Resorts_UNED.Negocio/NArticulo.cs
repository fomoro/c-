using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Data;

namespace Resorts_UNED.Negocio
{
    public class NArticulo
    {
        private readonly DArticulo datos = new DArticulo();

        public DataTable Listar()
        {
            try
            {
                return datos.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerConCategoria()
        {
            try
            {
                return datos.ObtenerConCategoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerPorHotel(string Valor)
        {
            try
            {
                return datos.ObtenerPorHotel(Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Buscar(string Valor)
        {
            try
            {
                return datos.Buscar(Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarConCategoria(string Valor)
        {
            try
            {
                var result = datos.BuscarConCategoria(Valor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Insertar(Articulo Obj)
        {
            try
            {
                string Existe = datos.Existe(Obj.Nombre);
                if (Existe.Equals("1"))
                {
                    return "El artículo ya existe";
                }
                else
                {
                    return datos.Insertar(Obj);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar(int Id, int IdCategoria, string Codigo, string NombreAnt, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            Articulo Obj = new Articulo();

            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdArticulo = Id;
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return datos.Actualizar(Obj);
            }
            else
            {
                string Existe = datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "El artículo ya existe";
                }
                else
                {
                    Obj.IdArticulo = Id;
                    Obj.IdCategoria = IdCategoria;
                    Obj.Codigo = Codigo;
                    Obj.Nombre = Nombre;
                    Obj.PrecioVenta = PrecioVenta;
                    Obj.Stock = Stock;
                    Obj.Descripcion = Descripcion;
                    Obj.Imagen = Imagen;
                    return datos.Actualizar(Obj);
                }
            }
        }
        public string Eliminar(int Id)
        {
            try
            {
                return datos.Eliminar(Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Activar(int Id)
        {
            try
            {
                return datos.Activar(Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Desactivar(int Id)
        {
            try
            {
                return datos.Desactivar(Id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
