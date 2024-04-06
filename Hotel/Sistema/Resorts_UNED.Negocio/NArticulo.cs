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
        public DataTable ObtenerPorCliente(string Valor)
        {
            try
            {
                return datos.ObtenerPorCliente(Valor);
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
        public string Actualizar(Articulo Obj)
        {
            if (datos.ExisteArticuloConEsteNombre(Obj.IdArticulo, Obj.Nombre))
            {
                return "Ya existe una categoría con este nombre.";
            }
            else
            {
                // Si no hay otra categoría con el mismo nombre, actualizar la categoría
                Articulo articulo = new Articulo()
                {
                    IdArticulo = Obj.IdArticulo,
                    IdCategoria = Obj.IdCategoria,
                    Nombre = Obj.Nombre,
                    PrecioVenta = Obj.PrecioVenta,
                    Descripcion = Obj.Descripcion,
                    Imagen = Obj.Imagen,
                    Estado = Obj.Estado
                };

                return datos.Actualizar(articulo);
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
