using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Negocio
{
    public class NArticulo
    {
        private Datos.DArticulo datosArticulo = new Datos.DArticulo();

        public DataTable ListarArticulos()
        {
            try
            {
                return datosArticulo.ListarArticulos();
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                Console.WriteLine("Error al listar los artículos: " + ex.Message);
                return null;
            }
        }

        public bool InsertarArticulo(string nombre, int precio, int idCategoria)
        {
            try
            {
                return datosArticulo.InsertarArticulo(nombre, precio, idCategoria);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                Console.WriteLine("Error al insertar el artículo: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarArticulo(int idArticulo, string nombre, int precio, int idCategoria)
        {
            try
            {
                return datosArticulo.ActualizarArticulo(idArticulo, nombre, precio, idCategoria);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                Console.WriteLine("Error al actualizar el artículo: " + ex.Message);
                return false;
            }
        }

        public bool EliminarArticulo(int idArticulo)
        {
            try
            {
                return datosArticulo.EliminarArticulo(idArticulo);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                Console.WriteLine("Error al eliminar el artículo: " + ex.Message);
                return false;
            }
        }
    }
}
