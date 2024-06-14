using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CategoriaPeliculaDAO
    {
        
        private static CategoriaPelicula[] categorias = new CategoriaPelicula[20];
        private static bool initialized = false;
        private static int currentIndex = 0;

        public CategoriaPeliculaDAO()
        {
            if (!initialized)
            {
                categorias[currentIndex++] = new CategoriaPelicula { Id = 1, Nombre = "Comedia", Descripcion = "Películas cómicas", Estado = true };
                categorias[currentIndex++] = new CategoriaPelicula { Id = 2, Nombre = "Drama", Descripcion = "Películas dramáticas", Estado = true };
                categorias[currentIndex++] = new CategoriaPelicula { Id = 3, Nombre = "Acción", Descripcion = "Películas de acción", Estado = true };
                categorias[currentIndex++] = new CategoriaPelicula { Id = 4, Nombre = "Terror", Descripcion = "Películas de terror", Estado = true };
                categorias[currentIndex++] = new CategoriaPelicula { Id = 5, Nombre = "Romance", Descripcion = "Películas de romance", Estado = true };

                categorias[currentIndex++] = new CategoriaPelicula { Id = 6, Nombre = "Ciencia Ficción", Descripcion = "Películas de ciencia ficción", Estado = false };
                initialized = true;
            }                        
        }
        public void AgregarCategoria(CategoriaPelicula categoria)
        {
            if (currentIndex >= 20)
            {
                throw new Exception("No se pueden agregar más categorías. Límite alcanzado.");
            }

            foreach (var cat in categorias)
            {
                if (cat != null && cat.Id == categoria.Id)
                {
                    throw new Exception("Ya existe una categoría con el mismo ID.");
                }
            }

            categorias[currentIndex] = categoria;
            currentIndex++;
        }
        public void ActualizarCategoria(CategoriaPelicula categoria)
        {
            // Buscamos la categoría en el arreglo
            for (int i = 0; i < currentIndex; i++)
            {
                if (categorias[i].Id == categoria.Id)
                {
                    // Actualizamos la categoría si la encontramos
                    categorias[i] = categoria;
                    return;
                }
            }

            // Si no encontramos la categoría, lanzamos una excepción
            throw new Exception("No se encontró la categoría con el ID especificado.");
        }
        public CategoriaPelicula[] ObtenerCategorias()
        {
            CategoriaPelicula[] categoriasActuales = new CategoriaPelicula[currentIndex];
            Array.Copy(categorias, categoriasActuales, currentIndex);
            return categoriasActuales;
        }
        public void EliminarCategoria(int id)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (categorias[i].Id == id)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        categorias[j] = categorias[j + 1];
                    }

                    categorias[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró la categoría con el ID especificado.");
            }
        }
        public void ActivarCategoria(int id)
        {
            CategoriaPelicula categoria = categorias.FirstOrDefault(c => c != null && c.Id == id);

            if (categoria == null)
            {
                throw new Exception("No se encontró la categoría con el ID especificado.");
            }

            categoria.Estado = true;
        }
        public void DesactivarCategoria(int id)
        {
            CategoriaPelicula categoria = categorias.FirstOrDefault(c => c != null && c.Id == id);

            if (categoria == null)
            {
                throw new Exception("No se encontró la categoría con el ID especificado.");
            }

            categoria.Estado = false;
        }        
    }
}
