using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AlquilerDAO
    {
        private Alquiler[] alquileres = new Alquiler[100];
        private int currentIndex = 0;

        public void AgregarAlquiler(Alquiler alquiler)
        {
            if (currentIndex >= 100)
            {
                throw new Exception("No se pueden agregar más alquileres. Límite alcanzado.");
            }

            foreach (var alq in alquileres)
            {
                if (alq != null && alq.Id == alquiler.Id)
                {
                    throw new Exception("Ya existe un alquiler con el mismo ID.");
                }
            }

            alquileres[currentIndex] = alquiler;
            currentIndex++;
        }
        public Alquiler[] ObtenerAlquileres()
        {
            Alquiler[] alquileresActuales = new Alquiler[currentIndex];
            Array.Copy(alquileres, alquileresActuales, currentIndex);
            return alquileresActuales;
        }
        public void MarcarComoDevuelto(int id)
        {
            foreach (var alq in alquileres)
            {
                if (alq != null && alq.Id == id)
                {
                    alq.Devuelto = true;
                    return;
                }
            }
            throw new Exception("No se encontró el alquiler con el ID especificado.");
        }
        public void ActualizarAlquiler(Alquiler alquiler)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (alquileres[i].Id == alquiler.Id)
                {
                    alquileres[i] = alquiler;
                    return;
                }
            }
            throw new Exception("No se encontró el alquiler con el ID especificado.");
        }
        public void EliminarAlquiler(int id)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (alquileres[i].Id == id)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        alquileres[j] = alquileres[j + 1];
                    }

                    alquileres[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró el alquiler con el ID especificado.");
            }
        }              
    }
}
