using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaPresentacion
{
    public partial class Mantenimiento_Proforma : Form
    {
        VerDetalle _owner1;

        PuntoVentaBL.Proforma objProforma = new PuntoVentaBL.Proforma();

        PuntoVentaBL.Prefactura objPrefactura = new PuntoVentaBL.Prefactura();

        public Mantenimiento_Proforma(VerDetalle owner)
        {
            InitializeComponent();
            _owner1 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner1.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mantenimiento_Proforma_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //this.objProforma.Id = Convert.ToInt32(txtComprobante.Text);
            //this.objProforma.PorcDesc = Convert.ToDecimal(txtPorcDesc.Text);
            //this.objProforma.TotalFactura = Convert.ToDecimal(txtTotal.Text);
            //this.objProforma.ModificaEncabezadoProforma();
            

        }

        private void Mantenimiento_Proforma_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }
    }
}
