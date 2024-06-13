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

        public void AgregarEncargado(Encargado encargado)
        {
            // Aquí puede agregar validaciones adicionales según las reglas de negocio

            // Comprobar si el encargado es nulo
            if (encargado == null)
            {
                throw new ArgumentException("El encargado no puede ser nulo.");
            }

            // Comprobar si el nombre del encargado es nulo o está vacío
            if (string.IsNullOrEmpty(encargado.Nombre))
            {
                throw new ArgumentException("El nombre del encargado es requerido.");
            }

            // Comprobar si la identificación del encargado es nula o está vacía
            if (string.IsNullOrEmpty(encargado.Identificacion))
            {
                throw new ArgumentException("La identificación del encargado es requerida.");
            }

            if (encargado.Id == 0 || string.IsNullOrEmpty(encargado.PrimerApellido) || string.IsNullOrEmpty(encargado.SegundoApellido) || encargado.FechaNacimiento == DateTime.MinValue || encargado.FechaIngreso == DateTime.MinValue)
            {
                throw new Exception("El encargado debe tener un ID, primer apellido, segundo apellido, fecha de nacimiento y fecha de ingreso válidos.");
            }

            // Después de todas las validaciones, agregar el encargado
            encargadoData.AgregarEncargado(encargado);
        }

        public Encargado[] ObtenerEncargados()
        {
            return encargadoData.ObtenerEncargados();
        }
    }

}
