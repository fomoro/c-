using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SucursalBL
    {
        private SucursalDAO sucursalData = new SucursalDAO();
        private EncargadoBL encargadoBusiness = new EncargadoBL();

        public void AgregarSucursal(Sucursal sucursal)
        {
            // Aquí puede agregar validaciones adicionales según las reglas de negocio

            // Comprobar si la sucursal es nula
            if (sucursal == null)
            {
                throw new ArgumentException("La sucursal no puede ser nula.");
            }

            // Comprobar si el nombre de la sucursal es nulo o está vacío
            if (string.IsNullOrEmpty(sucursal.Nombre))
            {
                throw new ArgumentException("El nombre de la sucursal es requerido.");
            }

            // Comprobar si el encargado de la sucursal es nulo
            if (sucursal.Encargado == null)
            {
                throw new ArgumentException("El encargado de la sucursal es requerido.");
            }

            // Comprobar si el encargado de la sucursal existe
            if (encargadoBusiness.ObtenerEncargados().All(e => e.Id != sucursal.Encargado.Id))
            {
                throw new ArgumentException("El encargado de la sucursal no existe.");
            }

            if (sucursal.Id == 0 || sucursal.Encargado == null || string.IsNullOrEmpty(sucursal.Direccion) || string.IsNullOrEmpty(sucursal.Telefono))
            {
                throw new Exception("La sucursal debe tener un ID, encargado, dirección y teléfono válidos.");
            }

            // Después de todas las validaciones, agregar la sucursal
            sucursalData.AgregarSucursal(sucursal);
        }
        public Sucursal[] ObtenerSucursales()
        {
            return sucursalData.ObtenerSucursales();
        }
        public Sucursal[] BuscarSucursalPorNombre(string nombre)
        {
            return sucursalData.ObtenerSucursales().Where(s => s.Nombre.Contains(nombre)).ToArray();
        }
    }

}
