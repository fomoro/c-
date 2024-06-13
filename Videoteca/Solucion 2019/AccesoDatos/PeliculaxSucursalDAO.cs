using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PeliculaxSucursalDAO
    {
        private PeliculaxSucursal[] peliculasxsucursal = new PeliculaxSucursal[100];
        private int currentIndex = 0;

        public void AgregarPeliculaxSucursal(PeliculaxSucursal peliculaxsucursal)
        {
            if (currentIndex >= 100)
            {
                throw new Exception("No se pueden agregar más registros. Límite alcanzado.");
            }

            foreach (var pxs in peliculasxsucursal)
            {
                if (pxs != null && pxs.Sucursal.Id == peliculaxsucursal.Sucursal.Id && pxs.Pelicula.Id == peliculaxsucursal.Pelicula.Id)
                {
                    throw new Exception("Ya existe un registro con la misma sucursal y película.");
                }
            }

            peliculasxsucursal[currentIndex] = peliculaxsucursal;
            currentIndex++;
        }

        public PeliculaxSucursal[] ObtenerPeliculasxSucursal()
        {
            PeliculaxSucursal[] pxsActuales = new PeliculaxSucursal[currentIndex];
            Array.Copy(peliculasxsucursal, pxsActuales, currentIndex);
            return pxsActuales;
        }
    }

}
