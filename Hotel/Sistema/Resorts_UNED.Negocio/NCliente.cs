namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class NCliente
        {
            private Datos.DCliente clienteDatos;

            public NCliente()
            {
                clienteDatos = new Datos.DCliente();
            }

            public DataTable ObtenerClientes()
            {
                return clienteDatos.ObtenerClientes();
            }

            public bool InsertarCliente(string identificacion, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, char genero)
            {
                Cliente cliente = new Cliente
                {
                    Identificacion = identificacion,
                    Nombre = nombre,
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    FechaNacimiento = fechaNacimiento,
                    Genero = genero
                };

                return clienteDatos.InsertarCliente(cliente);
            }

            public bool ActualizarCliente(string identificacion, string nombre, string apellido1, string apellido2, DateTime fechaNacimiento, char genero)
            {
                Cliente cliente = new Cliente
                {
                    Identificacion = identificacion,
                    Nombre = nombre,
                    Apellido1 = apellido1,
                    Apellido2 = apellido2,
                    FechaNacimiento = fechaNacimiento,
                    Genero = genero
                };

                return clienteDatos.ActualizarCliente(cliente);
            }

            public bool EliminarCliente(string identificacion)
            {
                return clienteDatos.EliminarCliente(identificacion);
            }
        }
    }
}
