namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class NCategoria
        {
            private readonly Datos.DCategoria datosCategoria = new Datos.DCategoria();

            // Método para listar todas las categorías de artículos
            public DataTable ListarCategorias()
            {
                try
                {
                    return datosCategoria.ListarCategorias();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para buscar una categoría de artículo por ID
            public DataTable BuscarCategoriaPorId(int idCategoria)
            {
                try
                {
                    return datosCategoria.BuscarCategoriaPorId(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para buscar una categoría de artículo por descripción
            public DataTable BuscarCategoriaPorNombre(string nombre)
            {
                try
                {
                    return datosCategoria.BuscarCategoriaPorNombre(nombre);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para insertar una nueva categoría de artículo
            public string Insertar(string nombre, string descripcion, bool estado)
            {
                try
                {
                    datosCategoria.InsertarCategoria(nombre, descripcion, estado);
                    return "OK";
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }

            // Método para actualizar una categoría de artículo
            public string ActualizarCategoria(int idCategoria, 
                string nombre, string descripcion, bool estado)
            {
                // Obtener la categoría actual
                var dataTable = datosCategoria.BuscarCategoriaPorId(idCategoria);

                // Si no se encontró la categoría, retornar un mensaje de error
                if (dataTable.Rows.Count == 0)
                {
                    return "La categoría no existe";
                }

                // Convertir el DataTable a un objeto Categoria
                var categoriaActual = new Categoria();
                categoriaActual.IdCategoria = idCategoria;
                categoriaActual.Nombre = dataTable.Rows[0]["Nombre"].ToString();
                categoriaActual.Descripcion = dataTable.Rows[0]["Descripcion"].ToString();
                categoriaActual.Estado = (bool)dataTable.Rows[0]["Estado"];

                // Si el nombre no ha cambiado, solo actualizar la descripción y el estado
                if (nombre.Equals(categoriaActual.Nombre))
                {
                    categoriaActual.Descripcion = descripcion;
                    categoriaActual.Estado = estado;
                    return datosCategoria.ActualizarCategoria(categoriaActual);
                }

                // Si el nombre ha cambiado, verificar si ya existe una categoría con ese nombre
                if (datosCategoria.ExisteCategoriaConEsteNombre(nombre))
                {
                    return "La categoría ya existe";
                }

                // Si el nombre no existe, actualizar la categoría
                categoriaActual.Nombre = nombre;
                categoriaActual.Descripcion = descripcion;
                categoriaActual.Estado = estado;
                return datosCategoria.ActualizarCategoria(categoriaActual);
            }

            // Método para eliminar una categoría de artículo
            public void EliminarCategoria(int idCategoria)
            {
                try
                {
                    datosCategoria.EliminarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para desactivar una categoría de artículo
            public void DesactivarCategoria(int idCategoria)
            {
                try
                {
                    datosCategoria.DesactivarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para activar una categoría de artículo
            public void ActivarCategoria(int idCategoria)
            {
                try
                {
                    datosCategoria.ActivarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }

}
