namespace Resorts_UNED.Entidades
{
    using System;
    using System.Data;

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
            public string ActualizarCategoria(int idCategoria, string nombre, string descripcion)
            {
                // Verificar si otro registro ya tiene el mismo nombre
                if (datosCategoria.ExisteCategoriaConEsteNombre(nombre, idCategoria))
                {
                    return "Ya existe una categoría con este nombre.";
                }
                else
                {
                    // Si no hay otra categoría con el mismo nombre, actualizar la categoría
                    Categoria categoria = new Categoria()
                    {
                        IdCategoria = idCategoria,
                        Nombre = nombre,
                        Descripcion = descripcion
                    };

                    return datosCategoria.ActualizarCategoria(categoria);
                }
            }
            
            // Método para eliminar una categoría de artículo
            public string EliminarCategoria(int idCategoria)
            {
                try
                {
                    return datosCategoria.EliminarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para desactivar una categoría de artículo
            public string DesactivarCategoria(int idCategoria)
            {
                try
                {
                    return datosCategoria.DesactivarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // Método para activar una categoría de artículo
            public string ActivarCategoria(int idCategoria)
            {
                try
                {
                    return datosCategoria.ActivarCategoria(idCategoria);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }

}
