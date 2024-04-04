using System;
using System.Collections.Generic;
using System.Linq;

namespace Server_Con_Objetos
{
    public class Data
    {
        public List<Cliente> Clientes { get; set; }

        public Data()
        {
            Clientes = new List<Cliente>();
            
            for (int i = 1; i <= 10; i++)
            {
                Cliente cliente = new Cliente
                {
                    Id = $"C{i}",
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

                Clientes.Add(cliente); 
            }
        }

        public bool ClienteExiste(Cliente cliente)
        {
            return Clientes.Any(c => c.Id == cliente.Id);
        }
    }
}