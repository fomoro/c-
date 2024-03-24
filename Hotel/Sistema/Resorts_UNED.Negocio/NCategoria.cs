using Resorts_UNED.Datos;
using Resorts_UNED.Entidades;
using System;
using System.Data;

namespace Resorts_UNED.Negocio
{
    public class NCategoria
    {
        private readonly Datos.DCategoria datosCategoria = new Datos.DCategoria();

        public DataTable Listar()
        {
            try
            {
                return datosCategoria.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarActivas()
        {
            try
            {
                return datosCategoria.ListarActivas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarPorId(int idCategoria)
        {
            try
            {
                return datosCategoria.BuscarPorId(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarPorNombre(string nombre)
        {
            try
            {
                return datosCategoria.BuscarPorNombre(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Insertar(string nombre, string descripcion, bool estado)
        {
            try
            {
                datosCategoria.Insertar(nombre, descripcion, estado);
                return "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Actualizar(int idCategoria, string nombre, string descripcion)
        {
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

                return datosCategoria.Actualizar(categoria);
            }
        }
        public string Eliminar(int idCategoria)
        {
            try
            {
                return datosCategoria.Eliminar(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Desactivar(int idCategoria)
        {
            try
            {
                return datosCategoria.Desactivar(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Activar(int idCategoria)
        {
            try
            {
                return datosCategoria.Activar(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
