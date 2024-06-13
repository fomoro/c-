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
        private Encargado[] encargados = new Encargado[20];
        private int currentIndex = 0;

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
    }

}
