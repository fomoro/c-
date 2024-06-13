using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Data;

namespace Resorts_UNED.Negocio
{
    public class NCliente
    {
        private readonly DCliente datos = new DCliente();

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
        public string Insertar(Cliente Obj)
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
        public string Actualizar(Cliente Obj)
        {
            string respuesta = datos.Existe_ConEsteNombre(Obj.Identificacion, Obj.Nombre);
            if (respuesta.Equals("True"))
            {
                return "Ya existe un cliente con este id.";
            }
            else
            {
                // Si no hay otro cliente con el mismo Id, actualizar el cliente
                return datos.Actualizar(Obj);
            }
        }        
        public string Eliminar(string Id)
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
        public Cliente ObtenerClientePorId(string Id)
        {
            try
            {
                return datos.ObtenerClientePorId(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable Login(string Email, string Clave)
        {
            DCliente Datos = new DCliente();
            return Datos.Login(Email, Clave);
        }
    }
}
