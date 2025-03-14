﻿using AccesoDatos;
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

        public string AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                ValidarPelicula(pelicula);
                peliculaData.AgregarPelicula(pelicula);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar la película: " + e.Message;
            }
        }
        public string ActualizarPelicula(Pelicula pelicula)
        {
            try
            {
                ValidarPelicula(pelicula);
                peliculaData.ActualizarPelicula(pelicula);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al actualizar la película: " + e.Message;
            }
        }
        private void ValidarPelicula(Pelicula pelicula)
        {
            if (pelicula == null || string.IsNullOrEmpty(pelicula.Titulo) || pelicula.Categoria == null || pelicula.AnoLanzamiento == 0 || string.IsNullOrEmpty(pelicula.Idioma) || categoriaBusiness.ObtenerCategorias().All(c => c.Id != pelicula.Categoria.Id))
            {
                throw new ArgumentException("Las propiedades de la película no son válidas.");
            }
        }
        public Pelicula[] ObtenerPeliculas()
        {
            return peliculaData.ObtenerPeliculas();
        }
        public PeliculaDetalle[] ObtenerPeliculasConDetalle()
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
        public Pelicula[] BuscarPeliculasPorTitulo(string titulo)
        {
            return peliculaData.ObtenerPeliculas().Where(p => p.Titulo.Contains(titulo)).ToArray();
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
        
    }
}
