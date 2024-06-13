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

        public void AgregarCliente(Cliente cliente)
        {
            // Aquí puede agregar validaciones adicionales según las reglas de negocio

            // Comprobar si el cliente es nulo
            if (cliente == null)
            {
                throw new ArgumentException("El cliente no puede ser nulo.");
            }

            // Comprobar si el nombre del cliente es nulo o está vacío
            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente es requerido.");
            }

            // Comprobar si la identificación del cliente es nula o está vacía
            if (string.IsNullOrEmpty(cliente.Identificacion))
            {
                throw new ArgumentException("La identificación del cliente es requerida.");
            }

            if (cliente.Id == 0 || string.IsNullOrEmpty(cliente.PrimerApellido) || string.IsNullOrEmpty(cliente.SegundoApellido) || cliente.FechaNacimiento == DateTime.MinValue || cliente.FechaRegistro == DateTime.MinValue)
            {
                throw new Exception("El cliente debe tener un ID, primer apellido, segundo apellido, fecha de nacimiento y fecha de registro válidos.");
            }

            // Después de todas las validaciones, agregar el cliente
            clienteData.AgregarCliente(cliente);
        }

        public Cliente[] ObtenerClientes()
        {
            return clienteData.ObtenerClientes();
        }
    }

}
