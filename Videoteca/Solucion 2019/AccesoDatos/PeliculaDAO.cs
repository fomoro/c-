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
        private Pelicula[] peliculas = new Pelicula[20];
        private int currentIndex = 0;

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
    }

}
