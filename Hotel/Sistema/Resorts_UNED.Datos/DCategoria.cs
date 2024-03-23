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

            // Método para buscar una categoría de artículo por ID
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

            // Método para buscar una categoría de artículo por descripción
            public DataTable BuscarCategoriaPorDescripcion(string descripcion)
            {
                DataTable dtResultado = new DataTable("Categoria");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BuscarCategoriaPorDescripcion", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@valor", descripcion);
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

            // Método para actualizar una categoría de artículo
            public string ActualizarCategoria(Categoria obj)
            {
                string Rpta = "";
                SqlConnection SqlCon = new SqlConnection();
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
                        sqlCmd.Parameters.AddWithValue("@Estado", obj.Estado);
                        sqlCmd.ExecuteNonQuery();
                        Rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
                    }

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

            // Método para eliminar una categoría de artículo
            public void EliminarCategoria(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("EliminarCategoria", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para desactivar una categoría de artículo
            public void DesactivarCategoria(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("DesactivarCategoria", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para activar una categoría de artículo
            public void ActivarCategoria(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ActivarCategoria", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public bool ExisteCategoriaConEsteNombre(string nombreCategoria)
            {
                using (SqlConnection conexionSql = Conexion.getInstancia().CrearConexion())
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand("ExisteCategoriaConEsteNombre", conexionSql);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Nombre", nombreCategoria);
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


        }
    }

}
