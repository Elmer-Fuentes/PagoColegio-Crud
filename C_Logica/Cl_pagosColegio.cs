using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Datos;
using CapaDatos;

namespace C_Logica
{
    public class Cl_pagosColegio
    {
        #region = "Instancia de clases";
        CD_conexion cd_pago = new CD_conexion();
        #endregion

        #region = "Mtd que consulta tipo de pago por medio de un parametro";

        public double MtdConsultaPrecioTipoPago(int CodigoTipoPago) // Cambiar nombre del metodo y Cambiar nombre variable  de entrada codigo
        {
            double Precio = 0;

            string QueryConsultaPrecio = "select precio from tipopagos where CodigoTipoPago = @CodigoTipoPago"; // Cambiar query que busca precio
            SqlCommand Command = new SqlCommand(QueryConsultaPrecio, cd_pago.MtdAbrirConexion()); // Instanciar la clase de conexion y abrir la conexion
            Command.Parameters.AddWithValue("@CodigoTipoPago", CodigoTipoPago); // Cambiar nombre del codigo, segun variable del query
            SqlDataReader reader = Command.ExecuteReader();

            if (reader.Read())
            {
                Precio = double.Parse(reader["precio"].ToString()); // Cambiar nombre variable precio
            }
            else
            {
                Precio = 0;
            }

            cd_pago.MtdCerrarConexion();
            return Precio;
        }
        #endregion


        public double MtdTotalTipoPago(int MesesPagar, double PrecioTipoPago)
        {
            return MesesPagar * PrecioTipoPago;
        }

        public double MtdMulta(int CodigoTipoPago, DateTime FechaPagar)
        {
            DateTime FechaHoy = DateTime.Now;

            if (CodigoTipoPago == 1 && FechaPagar < FechaHoy) return 200;
            if (CodigoTipoPago == 2 && FechaPagar < FechaHoy) return 100;
            if (CodigoTipoPago == 5 && FechaPagar < FechaHoy) return 25;
            return 0;
        }

        public double MtdMontoPagar(double TotalTipoPago, double Multa)
        {
            return TotalTipoPago + Multa;
        }

    }
}
