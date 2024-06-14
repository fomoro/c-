using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class EncargadoDAO
    {
        private static Encargado[] encargados = new Encargado[20];
        private static bool initialized = false;
        private static int currentIndex = 0;

        public EncargadoDAO()
        {
            if (!initialized)
            {
                encargados[currentIndex++] = new Encargado { Id = 1, Identificacion = "3321", Nombre = "Esteban", PrimerApellido = "Garzon", SegundoApellido = "Rodriguez", FechaNacimiento = new DateTime(1990, 1, 1), FechaIngreso = DateTime.Now };
                encargados[currentIndex++] = new Encargado { Id = 2, Identificacion = "6654", Nombre = "Deisy", PrimerApellido = "Avila", SegundoApellido = "Lopez", FechaNacimiento = new DateTime(1992, 2, 2), FechaIngreso = DateTime.Now };
                encargados[currentIndex++] = new Encargado { Id = 3, Identificacion = "9987", Nombre = "Federico", PrimerApellido = "Corallo", SegundoApellido = "Morales", FechaNacimiento = new DateTime(1994, 3, 3), FechaIngreso = DateTime.Now };
                encargados[currentIndex++] = new Encargado { Id = 4, Identificacion = "1111", Nombre = "Juan", PrimerApellido = "Sarmiento", SegundoApellido = "Alvarez", FechaNacimiento = new DateTime(1996, 4, 4), FechaIngreso = DateTime.Now };
                encargados[currentIndex++] = new Encargado { Id = 5, Identificacion = "6554", Nombre = "Alejandra", PrimerApellido = "Beltran", SegundoApellido = "Ureña", FechaNacimiento = new DateTime(1998, 5, 5), FechaIngreso = DateTime.Now };
                encargados[currentIndex++] = new Encargado { Id = 5, Identificacion = "1024", Nombre = "Tomas", PrimerApellido = "Moreno", SegundoApellido = "Ureña", FechaNacimiento = new DateTime(1998, 5, 5), FechaIngreso = DateTime.Now };

                initialized = true;
            }
        }

        public void AgregarEncargado(Encargado encargado)
        {
            if (currentIndex >= 20)
            {
                throw new Exception("No se pueden agregar más encargados. Límite alcanzado.");
            }

            foreach (var enc in encargados)
            {
                if (enc != null && enc.Id == encargado.Id)
                {
                    throw new Exception("Ya existe un encargado con el mismo ID.");
                }
            }

            encargados[currentIndex] = encargado;
            currentIndex++;
        }

        public Encargado[] ObtenerEncargados()
        {
            Encargado[] encargadosActuales = new Encargado[currentIndex];
            Array.Copy(encargados, encargadosActuales, currentIndex);
            return encargadosActuales;
        }

        public void ActualizarEncargado(Encargado encargado)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (encargados[i].Id == encargado.Id)
                {
                    encargados[i] = encargado;
                    return;
                }
            }
            throw new Exception("No se encontró el encargado con el ID especificado.");
        }

        public void EliminarEncargado(int id)
        {
            bool encontrado = false;

            for (int i = 0; i < currentIndex; i++)
            {
                if (encargados[i].Id == id)
                {
                    // Mueve todos los elementos hacia arriba en el arreglo
                    for (int j = i; j < currentIndex - 1; j++)
                    {
                        encargados[j] = encargados[j + 1];
                    }

                    encargados[currentIndex - 1] = null; // Limpiar la última posición
                    currentIndex--;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                throw new Exception("No se encontró el encargado con el ID especificado.");
            }
        }

        public void ActivarEncargado(int id)
        {
            Encargado encargado = encargados.FirstOrDefault(e => e != null && e.Id == id);

            if (encargado == null)
            {
                throw new Exception("No se encontró el encargado con el ID especificado.");
            }

            encargado.Activo = true;
        }

        public void DesactivarEncargado(int id)
        {
            Encargado encargado = encargados.FirstOrDefault(e => e != null && e.Id == id);

            if (encargado == null)
            {
                throw new Exception("No se encontró el encargado con el ID especificado.");
            }

            encargado.Activo = false;
        }

    }

}
