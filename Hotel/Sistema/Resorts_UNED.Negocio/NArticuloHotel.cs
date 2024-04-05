using Resorts_UNED.Datos;
using System;
using System.Data;
using System.Linq;

namespace Resorts_UNED.Negocio
{
    public class NArticuloHotel
    {
        private DArticuloHotel datosArticuloHotel;

        public NArticuloHotel()
        {
            this.datosArticuloHotel = new DArticuloHotel();
        }

        public void ActualizarDetalle(DataTable originalData, DataTable newData, int idHotel)
        {
            try
            {
                // Eliminar las asignaciones que ya no están presentes en newData
                foreach (DataRow row in originalData.Rows)
                {
                    int idAsignacion = Convert.ToInt32(row["IdAsignacion"]);
                    if (!DataRowExists(newData, idAsignacion))
                    {
                        datosArticuloHotel.EliminarAsignacion(idAsignacion);
                    }
                }

                // Agregar nuevas asignaciones que están en newData pero no en originalData
                foreach (DataRow row in newData.Rows)
                {
                    int idAsignacion = Convert.ToInt32(row["IdAsignacion"]);
                    if (!DataRowExists(originalData, idAsignacion))
                    {
                        int idArticulo = Convert.ToInt32(row["Id"]);
                        DateTime fecha = DateTime.Now;
                        //DateTime fecha = Convert.ToDateTime(row["FechaAsignacion"]);
                        datosArticuloHotel.InsertarAsignacion(idHotel, idArticulo, fecha);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw ex;
            }
        }

        private bool DataRowExists(DataTable dataTable, int idAsignacion)
        {
            return dataTable.AsEnumerable().Any(row => Convert.ToInt32(row["IdAsignacion"]) == idAsignacion);
        }
    }
}
