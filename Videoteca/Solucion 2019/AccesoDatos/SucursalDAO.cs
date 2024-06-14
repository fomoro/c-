using Entidades;
using System;
using System.Linq;

namespace AccesoDatos
{
    public class SucursalDAO
    {
        private static Sucursal[] sucursales = new Sucursal[3];
        private static bool initialized = false;
        private static int currentIndex = 0;

        public SucursalDAO()
        {
            if (!initialized)
            {
                EncargadoDAO encargadoDAO = new EncargadoDAO();
                Encargado[] encargados = encargadoDAO.ObtenerEncargados();
                int index = 0;
                foreach (Encargado encargado in encargados)
                {
                    sucursales[currentIndex++] = new Sucursal { Id = currentIndex, Nombre = "Sucursal " + currentIndex, Encargado = encargado, Direccion = "Direccion " + currentIndex, Telefono = "Telefono " + currentIndex, Activo = true };
                    index++;
                    if (index >= 3) break;
                }
                initialized = true;
            }
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
        public Sucursal[] ObtenerSucursales()
        {
            Sucursal[] sucursalesActuales = new Sucursal[currentIndex];
            Array.Copy(sucursales, sucursalesActuales, currentIndex);
            return sucursalesActuales;
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
