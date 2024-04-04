using Resorts_UNED.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Resorts_UNED.Datos
{
    public class DCliente
    {
        private Conexion conexion;
        public DCliente()
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
                SqlCommand Comando = new SqlCommand("Clientes", SqlCon);
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
                SqlCommand Comando = new SqlCommand("ClientesPorNombre", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Cliente_Existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Identificacion", Valor);
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
        public string Existe_ConEsteNombre(string Identificacion, string nombre)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Cliente_ConEsteNombre", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Id", Identificacion);
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
        public string Insertar(Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Cliente_Insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Identificacion", Obj.Identificacion);
                Comando.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                Comando.Parameters.AddWithValue("@PrimerApellido", Obj.PrimerApellido);
                Comando.Parameters.AddWithValue("@SegundoApellido", Obj.SegundoApellido);
                Comando.Parameters.AddWithValue("@FechaNacimiento", Obj.FechaNacimiento);
                Comando.Parameters.AddWithValue("@Genero", Obj.Genero);
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
        public string Actualizar(Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Cliente_Actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Identificacion", Obj.Identificacion);
                Comando.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                Comando.Parameters.AddWithValue("@PrimerApellido", Obj.PrimerApellido);
                Comando.Parameters.AddWithValue("@SegundoApellido", Obj.SegundoApellido);
                Comando.Parameters.AddWithValue("@FechaNacimiento", Obj.FechaNacimiento);
                Comando.Parameters.AddWithValue("@Genero", Obj.Genero);
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
        public string Eliminar(string Id)
        {
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Cliente_Eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@Identificacion", Id);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                return "Cliente eliminado correctamente.";
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

        public DataTable Login(string Email, string Clave)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("cliente_login", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
