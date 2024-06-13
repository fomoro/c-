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
            ValidarPelicula(pelicula);

            // Después de todas las validaciones, agregar la película
            peliculaData.AgregarPelicula(pelicula);
        }

        public string ActualizarPelicula(Pelicula pelicula)
        {
            try
            {
                ValidarPelicula(pelicula);

                // Si todas las validaciones pasan, actualizar la película
                peliculaData.ActualizarPelicula(pelicula);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al actualizar la película: " + e.Message;
            }
        }

        private void ValidarPelicula(Pelicula pelicula)
        {
            if (pelicula == null || pelicula.Id == 0 || string.IsNullOrEmpty(pelicula.Titulo) || pelicula.Categoria == null || pelicula.AnoLanzamiento == 0 || string.IsNullOrEmpty(pelicula.Idioma) || categoriaBusiness.ObtenerCategorias().All(c => c.Id != pelicula.Categoria.Id))
            {
                throw new ArgumentException("Las propiedades de la película no son válidas.");
            }
        }

        public Pelicula[] ObtenerPeliculasXXXXXXXXXX()
        {
            return peliculaData.ObtenerPeliculas();
        }

        public PeliculaDetalle[] ObtenerPeliculas()
        {
            return peliculaData.ObtenerPeliculas().Select(p => new PeliculaDetalle
            {
                Id = p.Id,
                Titulo = p.Titulo,
                AnoLanzamiento = p.AnoLanzamiento,
                Idioma = p.Idioma,
                Estado = p.Estado,
                IdCategoria = p.Categoria.Id,
                NombreCategoria = p.Categoria.Nombre
            }).ToArray();
        }
        public string EliminarPelicula(int id)
        {
            try
            {
                peliculaData.EliminarPelicula(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al eliminar la película: " + e.Message;
            }
        }

        public string ActivarPelicula(int id)
        {
            try
            {
                peliculaData.ActivarPelicula(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al activar la película: " + e.Message;
            }
        }

        public string DesactivarPelicula(int id)
        {
            try
            {
                peliculaData.DesactivarPelicula(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al desactivar la película: " + e.Message;
            }
        }

        public Pelicula[] BuscarPeliculasPorNombre(string nombre)
        {
            return peliculaData.BuscarPeliculasPorNombre(nombre);
        }
    }
}
