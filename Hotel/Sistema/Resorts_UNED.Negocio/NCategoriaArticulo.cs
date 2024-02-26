namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class NCategoriaArticulo
        {
            private readonly Datos.DCategoriaArticulo datosCategoriaArticulo = new Datos.DCategoriaArticulo();

            // Método para listar todas las categorías de artículos
            public DataTable ListarCategoriasArticulo()
            {
                try
                {
                    return datosCategoriaArticulo.ListarCategoriasArticulo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para buscar una categoría de artículo por ID
            public DataTable BuscarCategoriaArticuloPorId(int idCategoria)
            {
                try
                {
                    return datosCategoriaArticulo.BuscarCategoriaArticuloPorId(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para buscar una categoría de artículo por descripción
            public DataTable BuscarCategoriaArticuloPorDescripcion(string descripcion)
            {
                try
                {
                    return datosCategoriaArticulo.BuscarCategoriaArticuloPorDescripcion(descripcion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para insertar una nueva categoría de artículo
            public void InsertarCategoriaArticulo(string descripcion, bool estado)
            {
                try
                {
                    datosCategoriaArticulo.InsertarCategoriaArticulo(descripcion, estado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para actualizar una categoría de artículo
            public void ActualizarCategoriaArticulo(int idCategoria, string descripcion, bool estado)
            {
                try
                {
                    datosCategoriaArticulo.ActualizarCategoriaArticulo(idCategoria, descripcion, estado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para eliminar una categoría de artículo
            public void EliminarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    datosCategoriaArticulo.EliminarCategoriaArticulo(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para desactivar una categoría de artículo
            public void DesactivarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    datosCategoriaArticulo.DesactivarCategoriaArticulo(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para activar una categoría de artículo
            public void ActivarCategoriaArticulo(int idCategoria)
            {
                try
                {
                    datosCategoriaArticulo.ActivarCategoriaArticulo(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para verificar si una categoría de artículo existe
            public bool ExisteCategoriaArticulo(int idCategoria)
            {
                try
                {
                    return datosCategoriaArticulo.ExisteCategoriaArticulo(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

}
