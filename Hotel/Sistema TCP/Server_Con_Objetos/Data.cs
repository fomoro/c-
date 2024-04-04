using System;
using System.Collections.Generic;
using System.Linq;

namespace Server_Con_Objetos
{
    public class Data
    {
        private List<Cliente> _clientes;

        public Data()
        {
            _clientes = new List<Cliente>();
            PoblarClientes();
        }

        public IReadOnlyList<Cliente> Clientes => _clientes;

        public Cliente ObtenerClientePorId(string id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public List<Articulo> ObtenerArticulosPorClienteId(string clienteId)
        {
            Cliente cliente = ObtenerClientePorId(clienteId);
            return cliente?.Articulos ?? new List<Articulo>();
        }

        private void PoblarClientes()
        {
            for (int i = 1; i <= 10; i++)
            {
                Cliente cliente = new Cliente
                {
                    Id = $"C{i}",
                    Clave = $"C{i}",
                    Nombre = $"Nombre{i}",
                    Apellido = $"Apellido{i}",
                    FechaNacimiento = DateTime.Now.AddYears(-20).AddDays(i)
                };

                for (int j = 1; j <= 2; j++)
                {
                    Articulo articulo = new Articulo
                    {
                        IdArticulo = i * 10 + j,
                        Nombre = $"Artículo{i * 10 + j}",
                        PrecioVenta = 10.50m * j,
                        Descripcion = $"Descripción del artículo {i * 10 + j}"
                    };

                    cliente.Articulos.Add(articulo);
                }

                _clientes.Add(cliente);
            }
        }
    }
}
