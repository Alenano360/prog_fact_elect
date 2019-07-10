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
    public partial class Cierre : Form
    {
        CajaDiaria_Mod _owner;

        PuntoVentaBL.ImprimeCierreCajaTicket objTicket = new PuntoVentaBL.ImprimeCierreCajaTicket();

        public Cierre(CajaDiaria_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkNoRep_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNoRep.Checked)
            {
                this.chkPDF.Checked = false;
                this.chkExcel.Checked = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.AgregaCajaDiariaCierre();

                if (this.chkCierreTicket.Checked)
                {
                    this.objTicket.Usuario = Login.LoginUsuarioFinal;

                    this.objTicket.print();
                }

                if (this.chkPDF.Checked)
                {
                    _owner.btnExpPDF_Click();
                }
                if (this.chkExcel.Checked)
                {
                    _owner.btnExpXLS_Click();
                }

             _owner.RealizaCierreCaja();

                this._owner.limpiadatagrid();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cierre_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void Cierre_Load(object sender, EventArgs e)
        {

        }

        private void chkCierreTicket_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
