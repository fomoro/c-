
namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {

        public class DHotel
        {
            private readonly Conexion conexion;

            public DHotel()
            {
                conexion = Conexion.getInstancia();
            }

            public DataTable ObtenerHoteles()
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    DataTable dtHoteles = new DataTable();
                    try
                    {
                        con.Open();
                        string query = "SELECT IdHotel, Nombre, Direccion, Estado, Telefono, IdUsuarioResponsable FROM Hotel";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtHoteles);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return dtHoteles;
                }
            }

            public DataTable ObtenerHotelPorId(int idHotel)
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    DataTable dtHotel = new DataTable();
                    try
                    {
                        con.Open();
                        string query = "SELECT IdHotel, Nombre, Direccion, Estado, Telefono, IdUsuarioResponsable FROM Hotel WHERE IdHotel = @IdHotel";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtHotel);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return dtHotel;
                }
            }

            public void InsertarHotel(string nombre, string direccion, bool estado, string telefono, int? idUsuarioResponsable)
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    try
                    {
                        con.Open();
                        string query = "INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono, IdUsuarioResponsable) VALUES (@Nombre, @Direccion, @Estado, @Telefono, @IdUsuarioResponsable)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@IdUsuarioResponsable", (object)idUsuarioResponsable ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            public void ActualizarHotel(int idHotel, string nombre, string direccion, bool estado, string telefono, int? idUsuarioResponsable)
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    try
                    {
                        con.Open();
                        string query = "UPDATE Hotel SET Nombre = @Nombre, Direccion = @Direccion, Estado = @Estado, Telefono = @Telefono, IdUsuarioResponsable = @IdUsuarioResponsable WHERE IdHotel = @IdHotel";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@IdUsuarioResponsable", (object)idUsuarioResponsable ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            public void EliminarHotel(int idHotel)
            {
                using (SqlConnection con = conexion.CrearConexion())
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM Hotel WHERE IdHotel = @IdHotel";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@IdHotel", idHotel);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
    }
}
