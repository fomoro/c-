using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Resorts_UNED.Negocio
{
    public class NPedido
    {
        private readonly DPedido datos = new DPedido();
        public void ActualizarDetalle(List<Pedido> pedidos, string idCliente)
        {
            try
            {
                datos.EliminarPedidosPorCliente(idCliente);
                foreach (var item in pedidos)
                {
                    datos.InsertarPedido(item.IdCliente, item.IdArticulo, item.FechaPedido);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
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
    }
}
