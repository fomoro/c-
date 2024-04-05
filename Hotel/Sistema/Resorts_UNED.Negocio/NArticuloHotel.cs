using Resorts_UNED.Datos;
using System;
using System.Data;
using System.Linq;

namespace Resorts_UNED.Negocio
{
    public class NArticuloHotel
    {
        private readonly DArticuloHotel _datosArticuloHotel;

        public NArticuloHotel()
        {
            _datosArticuloHotel = new DArticuloHotel();
        }

        public void ActualizarDetalle(DataTable datosOriginales, DataTable nuevosDatos, int idHotel)
        {
            try
            {
                EliminarAsignacionesFaltantes(datosOriginales, nuevosDatos);
                AgregarNuevasAsignaciones(datosOriginales, nuevosDatos, idHotel);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        private void EliminarAsignacionesFaltantes(DataTable datosOriginales, DataTable nuevosDatos)
        {
            foreach (DataRow row in datosOriginales.Rows)
            {
                if (!DataRowExists(nuevosDatos, Convert.ToInt32(row["IdAsignacion"])))
                {
                    _datosArticuloHotel.EliminarAsignacion(Convert.ToInt32(row["IdAsignacion"]));
                }
            }
        }

        private void AgregarNuevasAsignaciones(DataTable datosOriginales, DataTable nuevosDatos, int idHotel)
        {
            foreach (DataRow row in nuevosDatos.Rows)
            {
                if (row.RowState != DataRowState.Deleted && !DataRowExists(datosOriginales, Convert.ToInt32(row["IdAsignacion"])))
                {
                    _datosArticuloHotel.InsertarAsignacion(idHotel, Convert.ToInt32(row["Id"]), DateTime.Now);
                }
            }
        }

        private bool DataRowExists(DataTable dataTable, int idAsignacion)
        {
            return dataTable.AsEnumerable()
                             .Any(row => row.RowState != DataRowState.Deleted &&
                                         Convert.ToInt32(row["IdAsignacion"]) == idAsignacion);
        }
    }
}
