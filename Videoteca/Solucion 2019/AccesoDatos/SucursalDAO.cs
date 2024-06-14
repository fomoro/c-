using Entidades;
using System;
using System.Linq;

namespace AccesoDatos
{
    public class SucursalDAO
    {
        private static Sucursal[] sucursales = new Sucursal[5];
        private static bool initialized = false;
        private static int currentIndex = 0;

        public SucursalDAO()
        {
            if (!initialized)
            {
                EncargadoDAO encargadoDAO = new EncargadoDAO();
                Encargado[] encargados = encargadoDAO.ObtenerEncargados();
                sucursales[currentIndex++] = new Sucursal { Id = currentIndex, Nombre = "Sucursal " + currentIndex, Encargado = encargados[0], Direccion = "Direccion " + currentIndex, Telefono = "Telefono " + currentIndex, Activo = true };
                sucursales[currentIndex++] = new Sucursal { Id = currentIndex, Nombre = "Sucursal " + currentIndex, Encargado = encargados[1], Direccion = "Direccion " + currentIndex, Telefono = "Telefono " + currentIndex, Activo = true };
                
                initialized = true;
            }
        }        
        public Sucursal[] ObtenerSucursales()
        {
            Sucursal[] sucursalesActuales = new Sucursal[currentIndex];
            Array.Copy(sucursales, sucursalesActuales, currentIndex);
            return sucursalesActuales;
        }

        public void AgregarSucursal(Sucursal sucursal)
        {
            if (currentIndex >= 3)
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
        public void ActualizarSucursal(Sucursal sucursal)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (sucursales[i].Id == sucursal.Id)
                {
                    sucursales[i] = sucursal;
                    return;
                }
            }
            throw new Exception("No se encontró la sucursal con el ID especificado.");
        }
        public void EliminarSucursal(int id)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (sucursales[i].Id == id)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        sucursales[j] = sucursales[j + 1];
                    }

                    sucursales[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró la sucursal con el ID especificado.");
            }
        }
        public void ActivarSucursal(int id)
        {
            Sucursal sucursal = sucursales.FirstOrDefault(s => s != null && s.Id == id);

            if (sucursal == null)
            {
                throw new Exception("No se encontró la sucursal con el ID especificado.");
            }

            sucursal.Activo = true;
        }
        public void DesactivarSucursal(int id)
        {
            Sucursal sucursal = sucursales.FirstOrDefault(s => s != null && s.Id == id);

            if (sucursal == null)
            {
                throw new Exception("No se encontró la sucursal con el ID especificado.");
            }

            sucursal.Activo = false;
        }
    }
}
