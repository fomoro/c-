using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaPeliculaBL
    {
        private CategoriaPeliculaDAO categoriaData = new CategoriaPeliculaDAO();

        public string AgregarCategoria(CategoriaPelicula categoria)
        {
            try
            {
                if (categoria == null || string.IsNullOrEmpty(categoria.Nombre) || string.IsNullOrEmpty(categoria.Descripcion))
                {
                    return "Los campos Nombre y Descripción son obligatorios";
                }

                categoriaData.AgregarCategoria(categoria);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al agregar la categoría: " + e.Message;
            }
        }   

        public CategoriaPelicula[] ObtenerCategorias()
        {
            return categoriaData.ObtenerCategorias();
        }

        public string ActualizarCategoria(CategoriaPelicula categoria)
        {
            try
            {
                if (categoria == null || string.IsNullOrEmpty(categoria.Nombre))
                {
                    return "El nombre de la categoría es requerido.";
                }

                categoriaData.ActualizarCategoria(categoria);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al actualizar la categoría: " + e.Message;
            }
        }
        public CategoriaPelicula[] BuscarCategoriaPorNombre(string nombre)
        {
            CategoriaPelicula[] todasLasCategorias = categoriaData.ObtenerCategorias();
            List<CategoriaPelicula> categoriasEncontradas = new List<CategoriaPelicula>();

            foreach (var categoria in todasLasCategorias)
            {
                if (categoria.Nombre.Contains(nombre))
                {
                    categoriasEncontradas.Add(categoria);
                }
            }

            return categoriasEncontradas.ToArray();
        }
        public string EliminarCategoria(int id)
        {
            try
            {
                categoriaData.EliminarCategoria(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al eliminar la categoría: " + e.Message;
            }
        }
        public string ActivarCategoria(int id)
        {
            try
            {
                categoriaData.ActivarCategoria(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al activar la categoría: " + e.Message;
            }
        }

        public string DesactivarCategoria(int id)
        {
            try
            {
                categoriaData.DesactivarCategoria(id);
                return "OK";
            }
            catch (Exception e)
            {
                return "Ocurrió un error al desactivar la categoría: " + e.Message;
            }
        }


    }

}
