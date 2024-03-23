using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Datos
{
    public class DArticuloHotel
    {
        private Conexion conexion;

        public DArticuloHotel()
        {
            this.conexion = Conexion.getInstancia();
        }

        public DataTable ObtenerAsignacionesPorHotel(int idHotel)
        {
            DataTable dtAsignaciones = new DataTable();
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetArticuloHotelByHotelId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtAsignaciones);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
            return dtAsignaciones;
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

        public void ActualizarAsignacion(int idAsignacion, int idHotel, int idArticulo, DateTime fecha)
        {
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateArticuloHotel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);
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

        public DataRow ObtenerAsignacionPorId(int idAsignacion)
        {
            DataRow drAsignacion = null;
            try
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetArticuloHotelById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        drAsignacion = dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
            return drAsignacion;
        }
    }
}
