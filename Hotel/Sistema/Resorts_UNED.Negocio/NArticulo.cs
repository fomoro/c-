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
        public string Actualizar(Entidades.Articulo Obj)
        {
            try
            {
                /*                       
                   if (NombreAnt.Equals(Obj.Nombre))
                   {
                       return datos.Actualizar(Obj);
                   }
                   else
                   {
                       string Existe = datos.Existe(Obj.Nombre);
                       if (Existe.Equals("1"))
                       {
                           return "El artículo ya existe";
                       }
                       else
                       {                            
                           return datos.Actualizar(Obj);
                       }
                   }
                   */
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
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
