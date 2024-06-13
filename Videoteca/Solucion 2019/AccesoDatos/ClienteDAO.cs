using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClienteDAO
    {
        private Cliente[] clientes = new Cliente[20];
        private int currentIndex = 0;

        public ClienteDAO()
        {
            // Agregar 5 clientes "quemados"
            clientes[currentIndex++] = new Cliente { Id = 1, Identificacion = "123", Nombre = "Juan", PrimerApellido = "Perez", SegundoApellido = "Rodriguez", FechaNacimiento = new DateTime(1990, 1, 1), FechaRegistro = DateTime.Now, Activo = true };
            clientes[currentIndex++] = new Cliente { Id = 2, Identificacion = "456", Nombre = "Maria", PrimerApellido = "Gomez", SegundoApellido = "Lopez", FechaNacimiento = new DateTime(1992, 2, 2), FechaRegistro = DateTime.Now, Activo = true };
            clientes[currentIndex++] = new Cliente { Id = 3, Identificacion = "789", Nombre = "Carlos", PrimerApellido = "Castro", SegundoApellido = "Morales", FechaNacimiento = new DateTime(1994, 3, 3), FechaRegistro = DateTime.Now, Activo = true };
            clientes[currentIndex++] = new Cliente { Id = 4, Identificacion = "321", Nombre = "Sofia", PrimerApellido = "Cordero", SegundoApellido = "Alvarez", FechaNacimiento = new DateTime(1996, 4, 4), FechaRegistro = DateTime.Now, Activo = true };
            clientes[currentIndex++] = new Cliente { Id = 5, Identificacion = "654", Nombre = "Miguel", PrimerApellido = "Mora", SegundoApellido = "Ureña", FechaNacimiento = new DateTime(1998, 5, 5), FechaRegistro = DateTime.Now, Activo = true };
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (currentIndex >= 20)
            {
                throw new Exception("No se pueden agregar más clientes. Límite alcanzado.");
            }

            foreach (var cli in clientes)
            {
                if (cli != null && cli.Id == cliente.Id)
                {
                    throw new Exception("Ya existe un cliente con el mismo ID.");
                }
            }

            clientes[currentIndex] = cliente;
            currentIndex++;
        }

        public Cliente[] ObtenerClientes()
        {
            Cliente[] clientesActuales = new Cliente[currentIndex];
            Array.Copy(clientes, clientesActuales, currentIndex);
            return clientesActuales;
        }
    }

}
