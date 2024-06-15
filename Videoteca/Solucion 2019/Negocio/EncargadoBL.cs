using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EncargadoBL
    {
        private EncargadoDAO encargadoData = new EncargadoDAO();
        public string AgregarEncargado(Encargado encargado)
        {
            try
            {
                ValidarEncargado(encargado);
                encargadoData.AgregarEncargado(encargado);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el encargado: " + e.Message;
            }
        }
        public string ActualizarEncargado(Encargado encargado)
        {
            try
            {
                ValidarEncargado(encargado);
                encargadoData.ActualizarEncargado(encargado);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al actualizar el encargado: " + e.Message;
            }
        }
        private void ValidarEncargado(Encargado encargado)
        {
            if (encargado == null)
            {
                throw new ArgumentException("El encargado no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(encargado.Nombre))
            {
                throw new ArgumentException("El nombre del encargado es requerido.");
            }

            if (string.IsNullOrEmpty(encargado.Identificacion))
            {
                throw new ArgumentException("La identificación del encargado es requerida.");
            }

            if (string.IsNullOrEmpty(encargado.PrimerApellido) || string.IsNullOrEmpty(encargado.SegundoApellido) || encargado.FechaNacimiento == DateTime.MinValue || encargado.FechaIngreso == DateTime.MinValue)
            {
                throw new Exception("El encargado debe tener un primer apellido, segundo apellido, fecha de nacimiento y fecha de ingreso válidos.");
            }

        }
        public Encargado[] ObtenerEncargados()
        {
            return encargadoData.ObtenerEncargados();
        }
        public Encargado[] BuscarEncargadoPorNombre(string nombre)
        {
            return encargadoData.ObtenerEncargados().Where(e => e.Nombre.Contains(nombre)).ToArray();
        }
    }

}