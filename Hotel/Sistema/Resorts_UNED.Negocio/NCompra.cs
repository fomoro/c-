using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Data;

namespace Resorts_UNED.Negocio
{
    public class NCompra
    {
        private readonly DCompra datos = new DCompra();

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
        public string Insertar(Hotel Obj)
        {
            try
            {
                string Existe = datos.Existe(Obj.Nombre);
                if (Existe.Equals("True"))
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
        public string Actualizar(Hotel Obj)
        {
            string respuesta = datos.Existe_ConEsteNombre(Obj.IdHotel, Obj.Nombre);
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
