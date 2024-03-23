using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resorts_UNED.Negocio
{
    public class NArticuloHotel
    {
        private Datos.DArticuloHotel datosAsignacion;

        public NArticuloHotel()
        {
            this.datosAsignacion = new Datos.DArticuloHotel();
        }

        public DataTable ObtenerAsignacionesPorHotel(int idHotel)
        {
            try
            {
                return datosAsignacion.ObtenerAsignacionesPorHotel(idHotel);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public void InsertarAsignacion(int idHotel, int idArticulo, DateTime fecha)
        {
            try
            {
                datosAsignacion.InsertarAsignacion(idHotel, idArticulo, fecha);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public void ActualizarAsignacion(int idAsignacion, int idHotel, int idArticulo, DateTime fecha)
        {
            try
            {
                datosAsignacion.ActualizarAsignacion(idAsignacion, idHotel, idArticulo, fecha);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public void EliminarAsignacion(int idAsignacion)
        {
            try
            {
                datosAsignacion.EliminarAsignacion(idAsignacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        public DataRow ObtenerAsignacionPorId(int idAsignacion)
        {
            try
            {
                return datosAsignacion.ObtenerAsignacionPorId(idAsignacion);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }
    }
}
