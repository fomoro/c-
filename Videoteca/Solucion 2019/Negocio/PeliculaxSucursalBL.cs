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
            if (peliculaxSucursal == null)
            {
                throw new ArgumentException("La asociación no puede ser nula.");
            }

            if (peliculaxSucursal.Sucursal == null)
            {
                throw new ArgumentException("La sucursal de la asociación es requerida.");
            }

            if (peliculaxSucursal.Pelicula == null)
            {
                throw new ArgumentException("La película de la asociación es requerida.");
            }

            if (sucursalBusiness.ObtenerSucursales().All(s => s.Id != peliculaxSucursal.Sucursal.Id))
            {
                throw new ArgumentException("La sucursal de la asociación no existe.");
            }

            if (peliculaBusiness.ObtenerPeliculas().All(p => p.Id != peliculaxSucursal.Pelicula.Id))
            {
                throw new ArgumentException("La película de la asociación no existe.");
            }

            if (peliculaxSucursal.Cantidad == 0)
            {
                throw new Exception("Debe tener una cantidad válida.");
            }

            peliculaxSucursalData.AgregarPeliculaxSucursal(peliculaxSucursal);
        }
        public PeliculaxSucursal[] ObtenerPeliculasxSucursal()
        {
            return peliculaxSucursalData.ObtenerPeliculasxSucursales();
        }
        public PeliculaxSucursalDetalle[] ObtenerPeliculasxSucursalDetalle()
        {
            return peliculaxSucursalData.ObtenerPeliculasxSucursales().Where(ps => ps != null).Select(ps => new PeliculaxSucursalDetalle
            {
                IdPelicula = ps.Pelicula.Id,
                TituloPelicula = ps.Pelicula.Titulo,
                IdSucursal = ps.Sucursal.Id,
                NombreSucursal = ps.Sucursal.Nombre,
                Cantidad = ps.Cantidad
               
            }).ToArray();
        }

    }
}
