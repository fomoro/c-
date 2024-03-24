using Resorts_UNED.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Resorts_UNED.Datos
{
    public class DCategoria
    {
        private Conexion conexion = Conexion.getInstancia();

        public DataTable Listar()
        {
            DataTable dtResultado = new DataTable("Categoria");
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Categorias_Listar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                    sqlDat.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtResultado;
        }
        public DataTable ListarActivas()
        {
            DataTable dtResultado = new DataTable("Categoria");
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Categoria_Activa", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                    sqlDat.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtResultado;
        }
        public void Insertar(string nombre, string descripcion, bool estado)
        {
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("CategoriaInsertar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nombre", nombre);
                    sqlCmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    sqlCmd.Parameters.AddWithValue("@Estado", estado);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Actualizar(Categoria obj)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("CategoriaActualizar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);
                    sqlCmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    sqlCmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
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
        public DataTable BuscarPorId(int idCategoria)
        {
            DataTable dtResultado = new DataTable("Categoria");
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("CategoriaBuscarPorId", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                    sqlDat.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtResultado;
        }
        public DataTable BuscarPorNombre(string nombre)
        {
            DataTable dtResultado = new DataTable("Categoria");
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("CategoriaBuscarPorNombre", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nombre", nombre);
                    SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                    sqlDat.Fill(dtResultado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtResultado;
        }
        public bool ExisteCategoriaConEsteNombre(string nombreCategoria, int idCategoria)
        {
            using (SqlConnection conexionSql = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand("CategoriaExisteConEsteNombre", conexionSql);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", nombreCategoria);
                    comando.Parameters.AddWithValue("@IdCategoria", idCategoria); // Nuevo parámetro
                    SqlParameter parExiste = new SqlParameter("@Existe", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    comando.Parameters.Add(parExiste);
                    conexionSql.Open();
                    comando.ExecuteNonQuery();
                    return Convert.ToBoolean(parExiste.Value);
                }
                catch
                {
                    return false;
                }
            }
        }
        public string Eliminar(int idCategoria)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Categoria_eliminar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@idcategoria", idCategoria);
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        public string Desactivar(int idCategoria)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Categoria_desactivar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@idcategoria", idCategoria);
                    Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        public string Activar(int idCategoria)
        {
            string Rpta = "";
            try
            {
                using (SqlConnection sqlCon = conexion.CrearConexion())
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Categoria_activar", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@idcategoria", idCategoria);
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
