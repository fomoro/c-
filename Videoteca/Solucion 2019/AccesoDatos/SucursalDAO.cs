using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class SucursalDAO
    {
        private Sucursal[] sucursales = new Sucursal[5];
        private int currentIndex = 0;

        public void AgregarSucursal(Sucursal sucursal)
        {
            if (currentIndex >= 5)
            {
                throw new Exception("No se pueden agregar más sucursales. Límite alcanzado.");
            }

            foreach (var suc in sucursales)
            {
                if (suc != null && suc.Id == sucursal.Id)
                {
                    throw new Exception("Ya existe una sucursal con el mismo ID.");
                }
            }

            sucursales[currentIndex] = sucursal;
            currentIndex++;
        }

        public Sucursal[] ObtenerSucursales()
        {
            Sucursal[] sucursalesActuales = new Sucursal[currentIndex];
            Array.Copy(sucursales, sucursalesActuales, currentIndex);
            return sucursalesActuales;
        }
    }

}
