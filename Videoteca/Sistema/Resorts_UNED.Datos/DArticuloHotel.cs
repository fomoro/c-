using System;
using System.Data.SqlClient;
using System.Data;

namespace Resorts_UNED.Datos
{
    public class DArticuloHotel
    {
        private Conexion conexion;

        public DArticuloHotel()
        {
            this.conexion = Conexion.getInstancia();
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
