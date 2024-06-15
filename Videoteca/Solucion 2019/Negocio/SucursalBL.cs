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
        
        public Sucursal[] ObtenerSucursales()
        {
            return sucursalData.ObtenerSucursales();
        }
        public SucursalDetalle[] ObtenerSucursalesConDetalle()
        {
            return sucursalData.ObtenerSucursales().Select(s => new SucursalDetalle
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Direccion = s.Direccion,
                Telefono = s.Telefono,                
                IdEncargado = s.Encargado.Id,
                NombreEncargado = s.Encargado.Nombre,
                Activo = s.Activo
            }).ToArray();
        }
        public Sucursal[] BuscarSucursalPorNombre(string nombre)
        {
            return sucursalData.ObtenerSucursales().Where(s => s.Nombre.Contains(nombre)).ToArray();
        }
        public string AgregarSucursal(Sucursal sucursal)
        {
            try
            {
                ValidarSucursal(sucursal);
                sucursalData.AgregarSucursal(sucursal);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar la sucursal: " + e.Message;
            }
        }

        public string ActualizarSucursal(Sucursal sucursal)
        {
            try
            {
                ValidarSucursal(sucursal);
                sucursalData.ActualizarSucursal(sucursal);
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al actualizar la sucursal: " + e.Message;
            }
        }

        private void ValidarSucursal(Sucursal sucursal)
        {
            if (sucursal == null)
            {
                throw new ArgumentException("La sucursal no puede ser nula.");
            }

            if (string.IsNullOrEmpty(sucursal.Nombre))
            {
                throw new ArgumentException("El nombre de la sucursal es requerido.");
            }

            if (sucursal.Encargado == null)
            {
                throw new ArgumentException("El encargado de la sucursal es requerido.");
            }

            if (string.IsNullOrEmpty(sucursal.Direccion))
            {
                throw new ArgumentException("La dirección de la sucursal es requerida.");
            }

            if (string.IsNullOrEmpty(sucursal.Telefono))
            {
                throw new ArgumentException("El teléfono de la sucursal es requerido.");
            }

            /*if (encargadoBusiness.ObtenerEncargados().All(e => e.Id != sucursal.Encargado.Id))
            {
                throw new ArgumentException("El encargado de la sucursal no existe.");
            }*/
        }
    }
}

