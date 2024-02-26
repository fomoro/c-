namespace Resorts_UNED.Entidades
{
    using global::Resorts_UNED.Datos;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    namespace Resorts_UNED.Datos
    {
        public class NHotel
        {
            private readonly Datos.DHotel datosHotel;

            public NHotel()
            {
                datosHotel = new Datos.DHotel();
            }

            public DataTable ObtenerHoteles()
            {
                try
                {
                    return datosHotel.ObtenerHoteles();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public DataTable ObtenerHotelPorId(int idHotel)
            {
                try
                {
                    return datosHotel.ObtenerHotelPorId(idHotel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void InsertarHotel(string nombre, string direccion, bool estado, string telefono, int? idUsuarioResponsable)
            {
                try
                {
                    datosHotel.InsertarHotel(nombre, direccion, estado, telefono, idUsuarioResponsable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ActualizarHotel(int idHotel, string nombre, string direccion, bool estado, string telefono, int? idUsuarioResponsable)
            {
                try
                {
                    datosHotel.ActualizarHotel(idHotel, nombre, direccion, estado, telefono, idUsuarioResponsable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void EliminarHotel(int idHotel)
            {
                try
                {
                    datosHotel.EliminarHotel(idHotel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
