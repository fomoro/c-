using System;
using System.Data.SqlClient;
using System.Data;

namespace Resorts_UNED.Datos
{
    public class DPedido
    {
        private Conexion conexion;

        public DPedido()
        {
            this.conexion = Conexion.getInstancia();
        }
        public DataTable ObtenerPorCliente(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Pedidos_PorCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public void InsertarPedido(string idCliente, int idArticulo, DateTime fecha)
        {
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Pedido_Insertar", con); // Nombre del procedimiento almacenado para insertar un pedido
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
                    cmd.Parameters.AddWithValue("@FechaPedido", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public void EliminarPedidosPorCliente(string idCliente)
        {
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Pedidos_BorrarPorIdCliente", con); // Nombre del procedimiento almacenado para eliminar pedidos por IdCliente
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

    }
}
