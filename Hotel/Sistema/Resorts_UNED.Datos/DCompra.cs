using Resorts_UNED.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Resorts_UNED.Datos
{
    public class DCompra
    {
        private readonly Conexion conexion;

        public DCompra()
        {
            conexion = Conexion.getInstancia();
        }
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Hoteles", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
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
        public DataTable Buscar(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Hoteles_PorNombre", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Valor);
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
        public string Existe(string Valor)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Hotel_Existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Valor);
                SqlParameter ExisteParam = new SqlParameter("@Existe", SqlDbType.Bit);
                ExisteParam.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ExisteParam);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                return Convert.ToString(ExisteParam.Value);
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
        public string Existe_ConEsteNombre(int Id, string nombre)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Hotel_ConEsteNombre", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Id", Id);
                Comando.Parameters.AddWithValue("@Nombre", nombre);
                SqlParameter ExisteParam = new SqlParameter("@Existe", SqlDbType.Bit);
                ExisteParam.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ExisteParam);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                return Convert.ToString(ExisteParam.Value);
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
        public string Insertar(Hotel Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Hotel_Insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                Comando.Parameters.AddWithValue("@Direccion", Obj.Direccion);
                Comando.Parameters.AddWithValue("@Estado", Obj.Estado);
                Comando.Parameters.AddWithValue("@Telefono", Obj.Telefono);
                //Comando.Parameters.AddWithValue("@Detalles", Obj.Detalles);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
        public string Actualizar(Hotel Obj)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Hotel_Actualizar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdHotel", Obj.IdHotel);
                    sqlCmd.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    sqlCmd.Parameters.AddWithValue("@Direccion", Obj.Direccion);
                    sqlCmd.Parameters.AddWithValue("@Estado", Obj.Estado);
                    sqlCmd.Parameters.AddWithValue("@Telefono", Obj.Telefono);
                    sqlCmd.ExecuteNonQuery();
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
                }

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        public string Eliminar(int Id)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Hotel_eliminar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdHotel", Id);
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        public string Desactivar(int id)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Hotel_Desactivar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdHotel", id);
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        public string Activar(int id)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Hotel_Activar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdHotel", id);
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
    }
}
