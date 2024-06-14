using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PeliculaDAO
    {
        private static Pelicula[] peliculas = new Pelicula[20];
        private static bool initialized = false;
        private static int currentIndex = 0;     

        public PeliculaDAO()
        {
            if (!initialized)
            {
                CategoriaPeliculaDAO categoriaDAO = new CategoriaPeliculaDAO();
                CategoriaPelicula[] categorias = categoriaDAO.ObtenerCategorias();
                peliculas[currentIndex++] = new Pelicula { Id = currentIndex, Titulo = "Pelicula " + currentIndex, Categoria = categorias[0], AnoLanzamiento = 2000, Idioma = "Español", Estado = true };
                peliculas[currentIndex++] = new Pelicula { Id = currentIndex, Titulo = "Pelicula " + currentIndex, Categoria = categorias[1], AnoLanzamiento = 2012, Idioma = "Español", Estado = true };
                peliculas[currentIndex++] = new Pelicula { Id = currentIndex, Titulo = "Pelicula " + currentIndex, Categoria = categorias[2], AnoLanzamiento = 1985, Idioma = "Español", Estado = true };

                initialized = true;
            }
        }

        public void AgregarPelicula(Pelicula pelicula)
        {
            if (currentIndex >= 20)
            {
                throw new Exception("No se pueden agregar más películas. Límite alcanzado.");
            }

            foreach (var peli in peliculas)
            {
                if (peli != null && peli.Id == pelicula.Id)
                {
                    throw new Exception("Ya existe una película con el mismo ID.");
                }
            }

            peliculas[currentIndex] = pelicula;
            currentIndex++;
        }

        public Pelicula[] ObtenerPeliculas()
        {
            Pelicula[] peliculasActuales = new Pelicula[currentIndex];
            Array.Copy(peliculas, peliculasActuales, currentIndex);
            return peliculasActuales;
        }

        public void ActualizarPelicula(Pelicula pelicula)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (peliculas[i].Id == pelicula.Id)
                {
                    peliculas[i] = pelicula;
                    return;
                }
            }
            throw new Exception("No se encontró la película con el ID especificado.");
        }

        public void EliminarPelicula(int id)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (peliculas[i].Id == id)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        peliculas[j] = peliculas[j + 1];
                    }

                    peliculas[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró la película con el ID especificado.");
            }
        }

        public void ActivarPelicula(int id)
        {
            Pelicula pelicula = peliculas.FirstOrDefault(p => p != null && p.Id == id);

            if (pelicula == null)
            {
                throw new Exception("No se encontró la película con el ID especificado.");
            }

            pelicula.Estado = true;
        }

        public void DesactivarPelicula(int id)
        {
            Pelicula pelicula = peliculas.FirstOrDefault(p => p != null && p.Id == id);

            if (pelicula == null)
            {
                throw new Exception("No se encontró la película con el ID especificado.");
            }

            pelicula.Estado = false;
        }
     
    }
}
