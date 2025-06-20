using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Datos;
using C_Logica;
using CapaDatos;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region = "Instancias de todas las clases";
        Cd_pagos cd_pagos = new Cd_pagos(); // Instanciar clase de conexion
        Cl_pagosColegio cl_pagosColegio = new Cl_pagosColegio(); // Instanciar clase de logica de negocio
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            MtdMostrarListaEstudiantes();
            MtdMostrarListaTipoPago();

        }

        #region = "cargar data a cbx_ListaEstudiantes" 
        private void MtdMostrarListaEstudiantes() // Cambiar nombre del metodo
        {
            var Lista = cd_pagos.MtdListaEstudiantes(); // Instanciar clase y cambiar nombre de metodo
            cboxCodigoEstudiante.Items.Clear(); //Cambiar el nombre del combobox
            
            cboxCodigoEstudiante.DataSource = Lista; //uso de datasource para agregar al combo box 

            cboxCodigoEstudiante.DisplayMember = "Text"; //la propiedad text es lo que se muestra en el combobox
            cboxCodigoEstudiante.ValueMember = "Value"; //Cambiar el nombre del combobox
        }
        #endregion

        #region = "Cargar data a cbx tipo de pago";
        private void MtdMostrarListaTipoPago() // Cambiar nombre del metodo
        {
            var Lista = cd_pagos.MtdListaTipoPago(); // Instanciar clase y cambiar nombre de metodo
            cboxTipoPago.Items.Clear(); //Cambiar el nombre del combobox

            cboxTipoPago.DataSource = Lista; //uso de datasource para agregar al combo box 

            cboxTipoPago.DisplayMember = "Text"; //la propiedad text es lo que se muestra en el combobox
            cboxTipoPago.ValueMember = "Value"; //Cambiar el nombre del combobox
        }

        #endregion

        //#region = "Capturar el codigo del cbx tipopago ||      REVISAR";
        //private void cboxTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Captura valor del combobox TipoPago y toma el codigo del tipo de pago seleccionado para enviar al metodo
        //    var selectedTipoPago = (dynamic)cboxTipoPago.SelectedItem; //Cambiar nombre al combobox
        //    int codigoTipoPago = (int)selectedTipoPago.GetType().GetProperty("Value").GetValue(selectedTipoPago, null); // Cambiar nombre de variable
        //    double Precio = cl_pagosColegio.MtdConsultaPrecioTipoPago(codigoTipoPago); // Cambiar nombre de Texbox, Instancia y metodo 
        //    txtPrecioTipoPago.Text = Precio.ToString(); // Concateno simbolo de moneda

        //    double Multa = cl_pagosColegio.MtdMulta(codigoTipoPago, dtpFechaApagar.Value);
        //    txtMulta.Text = Multa.ToString("c");

        //    int MesesPagar = 0;
        //    if (string.IsNullOrEmpty(txtMesesApagar.Text)) MesesPagar = 0;
        //    else MesesPagar = int.Parse(txtMesesApagar.Text);

        //    double TotalTipoPago = cl_pagosColegio.MtdTotalTipoPago(MesesPagar, Precio);
        //    txtTotalTipoPago.Text = TotalTipoPago.ToString("c");


        //    txtMontoApagar.Text = cl_pagosColegio.MtdMontoPagar(TotalTipoPago, Multa).ToString("c");
        //}
        //#endregion 
    }
}
