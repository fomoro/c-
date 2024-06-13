using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PeliculaBL
    {
        private PeliculaDAO peliculaData = new PeliculaDAO();
        private CategoriaPeliculaBL categoriaBusiness = new CategoriaPeliculaBL();

        public void AgregarPelicula(Pelicula pelicula)
        {
            
            if (pelicula.Id == 0)
            {
                throw new ArgumentException("La película no puede tener id 0");
            }

            // Comprobar si la película es nula
            if (pelicula == null)
            {
                throw new ArgumentException("La película no puede ser nula.");
            }

            // Comprobar si el título de la película es nulo o está vacío
            if (string.IsNullOrEmpty(pelicula.Titulo))
            {
                throw new ArgumentException("El título de la película es requerido.");
            }

            // Comprobar si la categoría de la película es nula
            if (pelicula.Categoria == null)
            {
                throw new ArgumentException("La categoría de la película es requerida.");
            }

            // Comprobar si la categoría de la película existe
            if (categoriaBusiness.ObtenerCategorias().All(c => c.Id != pelicula.Categoria.Id))
            {
                throw new ArgumentException("La categoría de la película no existe.");
            }

            if (pelicula.AnoLanzamiento == 0)
            {
                throw new ArgumentException("El año de lanzamiento de la película no es valido.");
            }

            if (string.IsNullOrEmpty(pelicula.Idioma))
            {
                throw new ArgumentException("Idioma de la película es requerido.");
            }


            // Después de todas las validaciones, agregar la película
            peliculaData.AgregarPelicula(pelicula);
        }

        public Pelicula[] ObtenerPeliculas()
        {
            return peliculaData.ObtenerPeliculas();
        }
    }

}
