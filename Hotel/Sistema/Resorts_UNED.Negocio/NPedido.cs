using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Data;

namespace Resorts_UNED.Negocio
{
    public class NPedido
    {
        private readonly DPedido datos = new DPedido();

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
    }
}
