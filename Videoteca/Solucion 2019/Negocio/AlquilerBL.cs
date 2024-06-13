using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AlquilerBL
    {
        private AlquilerDAO dao = new AlquilerDAO();

        public void AgregarAlquiler(Alquiler alquiler)
        {
            if (alquiler.Id == 0 || alquiler.Cliente == null || alquiler.PeliculaxSucursal == null || alquiler.FechaAlquiler == DateTime.MinValue || alquiler.FechaDevolucion == DateTime.MinValue)
            {
                throw new Exception("El alquiler debe tener un ID, cliente, película x sucursal, fecha de alquiler y fecha de devolución válidos.");
            }

            if (alquiler.FechaDevolucion < alquiler.FechaAlquiler)
            {
                throw new Exception("La fecha de devolución no puede ser anterior a la fecha de alquiler.");
            }

            dao.AgregarAlquiler(alquiler);
        }

        public Alquiler[] ObtenerAlquileres()
        {
            Alquiler[] alquileres = dao.ObtenerAlquileres();

            // Ordenar los alquileres por fecha de alquiler
            Array.Sort(alquileres, (a, b) => a.FechaAlquiler.CompareTo(b.FechaAlquiler));

            return alquileres;
        }

        public void MarcarComoDevuelto(int id)
        {
            Alquiler[] alquileres = ObtenerAlquileres();

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

    }

}
