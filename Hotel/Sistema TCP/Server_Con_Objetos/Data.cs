using System;
using System.Collections.Generic;
using System.Linq;

namespace Server_Con_Objetos
{
    public class Data
    {
        private readonly List<Cliente> _clientes;
        private readonly List<Articulo> _productos;
        public Data()
        {
            _clientes = new List<Cliente>();
            _productos = new List<Articulo>();

            PoblarClientes();
            PoblarProductos();
        }
        public IReadOnlyList<Cliente> Clientes => _clientes;
        public IReadOnlyList<Articulo> Productos => _productos;
        public Cliente ObtenerClienteConArticulos(string id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }
        public List<Articulo> ObtenerProductos()
        {
            return _productos.ToList();
        }
        private void PoblarProductos()
        {
            for (int i = 1; i <= 15; i++)
            {
                var producto = new Articulo
                {
                    IdArticulo = i,
                    Nombre = $"Producto {i}",
                    PrecioVenta = Math.Round(10 + i * 0.5m, 2),
                    Descripcion = $"Descripción del producto {i}"
                };

                _productos.Add(producto);
            }
        }
        private void PoblarClientes()
        {
            for (int i = 1; i <= 10; i++)
            {
                var cliente = CrearCliente($"C{i}", $"Nombre{i}", $"Apellido{i}", DateTime.Now.AddYears(-20).AddDays(i), 2);
                _clientes.Add(cliente);
            }
        }
        private Cliente CrearCliente(string id, string nombre, string apellido, DateTime fechaNacimiento, int numArticulos)
        {
            var cliente = new Cliente
            {
                Id = id,
                Clave = id, // Usar el ID como clave por defecto
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                Articulos = new List<Articulo>()
            };

            for (int j = 1; j <= numArticulos; j++)
            {
                var articulo = CrearArticulo(cliente.Id, $"Artículo{cliente.Id}{j}", 10.50m * j, $"Descripción del artículo {cliente.Id}{j}");
                cliente.Articulos.Add(articulo);
            }

            return cliente;
        }
        private Articulo CrearArticulo(string id, string nombre, decimal precioVenta, string descripcion)
        {
            return new Articulo
            {
                IdArticulo = int.Parse(id.Substring(1)) * 10 + _clientes.Count + 1,
                Nombre = nombre,
                PrecioVenta = precioVenta,
                Descripcion = descripcion
            };
        }
    }
}
