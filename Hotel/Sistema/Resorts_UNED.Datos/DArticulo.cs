using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Datos
{
    public class DArticulo
    {
        private Conexion conexion = Conexion.getInstancia();

        public DataTable ListarArticulos()
        {
            DataTable dtArticulos = new DataTable("Articulos");
            try
            {
                using (SqlConnection cn = conexion.CrearConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Articulo", cn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtArticulos);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error al listar los artículos: " + ex.Message);
            }
            return dtArticulos;
        }

        public bool InsertarArticulo(string nombre, int precio, int idCategoria)
        {
            try
            {
                using (SqlConnection cn = conexion.CrearConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Articulo (Nombre, Precio, IdCategoria) VALUES (@Nombre, @Precio, @IdCategoria)", cn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error al insertar el artículo: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarArticulo(int idArticulo, string nombre, int precio, int idCategoria)
        {
            try
            {
                using (SqlConnection cn = conexion.CrearConexion())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Articulo SET Nombre = @Nombre, Precio = @Precio, IdCategoria = @IdCategoria WHERE IdArticulo = @IdArticulo", cn);
                    cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error al actualizar el artículo: " + ex.Message);
                return false;
            }
        }

        public bool EliminarArticulo(int idArticulo)
        {
            try
            {
                using (SqlConnection cn = conexion.CrearConexion())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Articulo WHERE IdArticulo = @IdArticulo", cn);
                    cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error al eliminar el artículo: " + ex.Message);
                return false;
            }
        }
    }
}
