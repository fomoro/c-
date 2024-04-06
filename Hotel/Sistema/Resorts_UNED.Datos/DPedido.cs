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

        public void InsertarAsignacion(int idHotel, int idArticulo, DateTime fecha)
        {
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertArticuloHotel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                    cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public void EliminarAsignacion(int idAsignacion)
        {
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteArticuloHotel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);
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
