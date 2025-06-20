using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class Cd_pagos
    {
        CD_conexion conexion = new CD_conexion(); //instancia de la clase CD_Conexion  

        #region = "MtdParacargar Codigo-Nombre estudiantes desde tbl_estudiantes";
        public List<dynamic> MtdListaEstudiantes() // Cambiar nombre metodo
        {
            List<dynamic> Lista = new List<dynamic>();
            string Consulta= "Select codigoestudiante,nombres from estudiantes;"; 
            SqlCommand cmd = new SqlCommand(Consulta, conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Lista.Add(new
                {
                    Value = reader["CodigoEstudiante"].ToString(), // Cambiar nombre de campo codigo segun query
                    Text = $"{reader["CodigoEstudiante"]} - {reader["Nombres"]}" // Cambiar codigo y nombre, segun query
                });
            }

            conexion.MtdCerrarConexion();
            return Lista;
        }
        #endregion

        #region = "MtdParacargar Codigo-Nombre tipo de pago tbl_tipopago";
        public List<dynamic> MtdListaTipoPago() // Cambiar nombre metodo
        {
            List<dynamic> Lista = new List<dynamic>();
            string Consulta = "select codigotipopago,nombretipopago from Tipopagos;";
            SqlCommand cmd = new SqlCommand(Consulta, conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Lista.Add(new
                {
                    Value = reader["codigotipopago"].ToString(), // Cambiar nombre de campo codigo segun query
                    Text = $"{reader["codigotipopago"]} - {reader["nombretipopago"]}" // Cambiar codigo y nombre, segun query

             
                });
            }

            conexion.MtdCerrarConexion();
            return Lista;
        }
        #endregion
    }

}
        
