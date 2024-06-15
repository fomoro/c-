using Entidades;
using System;
using System.Linq;

namespace AccesoDatos
{
    public class PeliculaxSucursalDAO
    {
        private static PeliculaxSucursal[] peliculasxSucursales = new PeliculaxSucursal[100];
        private static bool initialized = false;
        private static int currentIndex = 0;
        public PeliculaxSucursalDAO()
        {
            if (!initialized)
            {

                PeliculaDAO peliculaDAO = new PeliculaDAO();
                SucursalDAO sucursalDAO = new SucursalDAO();
                Pelicula[] peliculas = peliculaDAO.ObtenerPeliculas();
                Sucursal[] sucursales = sucursalDAO.ObtenerSucursales();

                peliculasxSucursales[currentIndex++] = new PeliculaxSucursal { Sucursal = sucursales[0], Pelicula = peliculas[0], Cantidad = 5 };
                peliculasxSucursales[currentIndex++] = new PeliculaxSucursal { Sucursal = sucursales[0], Pelicula = peliculas[1], Cantidad = 3 };

                initialized = true;
            }
        }

        public void AgregarPeliculaxSucursal(PeliculaxSucursal nuevaPeliculaxSucursal)
        {
            if (currentIndex >= 100)
            {
                throw new Exception("No se pueden agregar más relaciones películas-sucursal. Límite alcanzado.");
            }

            foreach (var ps in peliculasxSucursales)
            {
                if (ps != null && ps.Pelicula.Id == nuevaPeliculaxSucursal.Pelicula.Id && ps.Sucursal.Id == nuevaPeliculaxSucursal.Sucursal.Id)
                {
                    throw new Exception("Ya existe una relación película-sucursal con los mismos IDs de Película y Sucursal.");
                }
            }

            peliculasxSucursales[currentIndex] = nuevaPeliculaxSucursal;
            currentIndex++;
        }
        public PeliculaxSucursal[] ObtenerPeliculasxSucursales()
        {
            PeliculaxSucursal[] peliculasxSucursalesActuales = new PeliculaxSucursal[currentIndex];
            Array.Copy(peliculasxSucursales, peliculasxSucursalesActuales, currentIndex);
            return peliculasxSucursalesActuales;
        }
        public void ActualizarPeliculaxSucursal(PeliculaxSucursal peliculaxSucursalActualizada)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (peliculasxSucursales[i] != null && peliculasxSucursales[i].Pelicula.Id == peliculaxSucursalActualizada.Pelicula.Id
                && peliculasxSucursales[i].Sucursal.Id == peliculaxSucursalActualizada.Sucursal.Id)
                {
                    peliculasxSucursales[i] = peliculaxSucursalActualizada;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró la relación película-sucursal especificada para actualizar.");
            }
        }
        public void EliminarPeliculaxSucursal(int peliculaId, int sucursalId)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (peliculasxSucursales[i] != null && 
                    peliculasxSucursales[i].Pelicula.Id == peliculaId && 
                    peliculasxSucursales[i].Sucursal.Id == sucursalId)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        peliculasxSucursales[j] = peliculasxSucursales[j + 1];
                    }

                    peliculasxSucursales[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró la relación película-sucursal especificada.");
            }
        }
    }
}
