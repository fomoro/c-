using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteBL
    {
        private ClienteDAO clienteData = new ClienteDAO();

        public string AgregarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                clienteData.AgregarCliente(cliente);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el cliente: " + e.Message;
            }
        }
        public string ActualizarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                clienteData.ActualizarCliente(cliente);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al actualizar el cliente: " + e.Message;
            }
        }
        private void ValidarCliente(Cliente cliente)
        {
            
            if (cliente == null)
            {
                throw new ArgumentException("El cliente no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente es requerido.");
            }

            if (string.IsNullOrEmpty(cliente.Identificacion))
            {
                throw new ArgumentException("La identificación del cliente es requerida.");
            }

            if (string.IsNullOrEmpty(cliente.PrimerApellido) || string.IsNullOrEmpty(cliente.SegundoApellido) || cliente.FechaNacimiento == DateTime.MinValue || cliente.FechaRegistro == DateTime.MinValue)
            {
                throw new Exception("El cliente debe tener un primer apellido, segundo apellido, fecha de nacimiento y fecha de registro válidos.");
            }

        }
        public Cliente[] ObtenerClientes()
        {
            return clienteData.ObtenerClientes();
        }
        public Cliente[] BuscarClientePorNombre(string nombre)
        {
            return clienteData.ObtenerClientes().Where(c => c.Nombre.Contains(nombre)).ToArray();
        }
    }
}
