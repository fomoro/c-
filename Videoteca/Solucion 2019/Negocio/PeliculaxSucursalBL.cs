using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PeliculaxSucursalBL
    {
        private PeliculaxSucursalDAO peliculaxSucursalData = new PeliculaxSucursalDAO();
        private SucursalBL sucursalBusiness = new SucursalBL();
        private PeliculaBL peliculaBusiness = new PeliculaBL();

        public void AgregarPeliculaxSucursal(PeliculaxSucursal peliculaxSucursal)
        {
            // Aquí puede agregar validaciones adicionales según las reglas de negocio

            // Comprobar si la asociación es nula
            if (peliculaxSucursal == null)
            {
                throw new ArgumentException("La asociación no puede ser nula.");
            }

            // Comprobar si la sucursal de la asociación es nula
            if (peliculaxSucursal.Sucursal == null)
            {
                throw new ArgumentException("La sucursal de la asociación es requerida.");
            }

            // Comprobar si la película de la asociación es nula
            if (peliculaxSucursal.Pelicula == null)
            {
                throw new ArgumentException("La película de la asociación es requerida.");
            }

            // Comprobar si la sucursal de la asociación existe
            if (sucursalBusiness.ObtenerSucursales().All(s => s.Id != peliculaxSucursal.Sucursal.Id))
            {
                throw new ArgumentException("La sucursal de la asociación no existe.");
            }

            // Comprobar si la película de la asociación existe
            if (peliculaBusiness.ObtenerPeliculas().All(p => p.Id != peliculaxSucursal.Pelicula.Id))
            {
                throw new ArgumentException("La película de la asociación no existe.");
            }

            if (peliculaxSucursal.Cantidad == 0)
            {
                throw new Exception("Debe tener una cantidad válida.");
            }

            // Después de todas las validaciones, agregar la asociación
            peliculaxSucursalData.AgregarPeliculaxSucursal(peliculaxSucursal);
        }

        public PeliculaxSucursal[] ObtenerPeliculasxSucursal()
        {
            return peliculaxSucursalData.ObtenerPeliculasxSucursal();
        }
    }

}
