namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class DCategoriaArticulo
        {
            private Conexion conexion = Conexion.getInstancia();

            // Método para listar todas las categorías de artículos
            public DataTable ListarCategoriasArticulo()
            {
                DataTable dtResultado = new DataTable("CategoriaArticulo");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ListarCategoriasArticulo", sqlCon);
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
            public DataTable BuscarCategoriaArticuloPorId(int idCategoria)
            {
                DataTable dtResultado = new DataTable("CategoriaArticulo");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BuscarCategoriaArticuloPorId", sqlCon);
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

            // Método para buscar una categoría de artículo por descripción
            public DataTable BuscarCategoriaArticuloPorDescripcion(string descripcion)
            {
                DataTable dtResultado = new DataTable("CategoriaArticulo");
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("BuscarCategoriaArticuloPorDescripcion", sqlCon);
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
            public void InsertarCategoriaArticulo(string descripcion, bool estado)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("InsertarCategoriaArticulo", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
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
            public void ActualizarCategoriaArticulo(int idCategoria, string descripcion, bool estado)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ActualizarCategoriaArticulo", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
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

            // Método para eliminar una categoría de artículo
            public void EliminarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("EliminarCategoriaArticulo", sqlCon);
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
            public void DesactivarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("DesactivarCategoriaArticulo", sqlCon);
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
            public void ActivarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ActivarCategoriaArticulo", sqlCon);
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

            // Método para verificar si una categoría de artículo existe
            public bool ExisteCategoriaArticulo(int idCategoria)
            {
                try
                {
                    using (SqlConnection sqlCon = conexion.CrearConexion())
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("ExisteCategoriaArticulo", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        sqlCmd.Parameters.Add("@Existe", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        sqlCmd.ExecuteNonQuery();
                        return Convert.ToBoolean(sqlCmd.Parameters["@Existe"].Value);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

}
