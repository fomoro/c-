
namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
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

            public DataTable ObtenerClientes()
            {
                DataTable dtClientes = new DataTable();
                try
                {
                    using (SqlConnection con = conexion.CrearConexion())
                    {
                        con.Open();
                        string query = "SELECT * FROM Cliente";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtClientes);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error al obtener clientes: " + ex.Message);
                }
                return dtClientes;
            }

            public bool InsertarCliente(Cliente cliente)
            {
                try
                {
                    using (SqlConnection con = conexion.CrearConexion())
                    {
                        con.Open();
                        string query = "INSERT INTO Cliente (Identificacion, Nombre, Apellido1, Apellido2, FechaNacimiento, Genero) VALUES (@Identificacion, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @Genero)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido1", cliente.Apellido1);
                        cmd.Parameters.AddWithValue("@Apellido2", cliente.Apellido2);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Genero", cliente.Genero);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error al insertar cliente: " + ex.Message);
                    return false;
                }
            }

            public bool ActualizarCliente(Cliente cliente)
            {
                try
                {
                    using (SqlConnection con = conexion.CrearConexion())
                    {
                        con.Open();
                        string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, FechaNacimiento = @FechaNacimiento, Genero = @Genero WHERE Identificacion = @Identificacion";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido1", cliente.Apellido1);
                        cmd.Parameters.AddWithValue("@Apellido2", cliente.Apellido2);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Genero", cliente.Genero);
                        cmd.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                    return false;
                }
            }

            public bool EliminarCliente(string identificacion)
            {
                try
                {
                    using (SqlConnection con = conexion.CrearConexion())
                    {
                        con.Open();
                        string query = "DELETE FROM Cliente WHERE Identificacion = @Identificacion";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                    return false;
                }
            }
        }

    }

}
