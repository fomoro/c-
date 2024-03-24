namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class DCategoria
        {
            private Conexion conexion = Conexion.getInstancia();

            // Método para listar todas las categorías de artículos
            public DataTable ListarCategorias()
            {
                DataTable dtResultado = new DataTable("Categoria");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ListarCategorias", sqlCon);
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
            // Método para insertar una nueva categoría de artículo
            public void InsertarCategoria(string nombre, string descripcion, bool estado)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("InsertarCategoria", sqlCon);
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

            public string ActualizarCategoria(Categoria obj)
            {
                string Rpta = "";
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ActualizarCategoria", sqlCon);
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
            public DataTable BuscarCategoriaPorId(int idCategoria)
            {
                DataTable dtResultado = new DataTable("Categoria");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BuscarCategoriaPorId", sqlCon);
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
            public DataTable BuscarCategoriaPorNombre(string nombre)
            {
                DataTable dtResultado = new DataTable("Categoria");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BuscarCategoriaPorNombre", sqlCon);
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
            // Método para verificar si existe una categoría con el mismo nombre pero diferente ID
            public bool ExisteCategoriaConEsteNombre(string nombreCategoria, int idCategoria)
            {
                using (SqlConnection conexionSql = Conexion.getInstancia().CrearConexion())
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand("ExisteCategoriaConEsteNombre", conexionSql);
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

            // Método para eliminar una categoría de artículo
            public string EliminarCategoria(int idCategoria)
            {
                string Rpta = "";
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("categoria_eliminar", sqlCon);
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

            public string DesactivarCategoria(int idCategoria)
            {
                string Rpta = "";
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("categoria_desactivar", sqlCon);
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

            public string ActivarCategoria(int idCategoria)
            {
                string Rpta = "";
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("categoria_activar", sqlCon);
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

}
