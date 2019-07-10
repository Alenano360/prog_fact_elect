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
    public partial class Apertura : Form
    {
        CajaDiaria_Mod _owner;

        public Apertura(CajaDiaria_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal x = Convert.ToDecimal(this.txtNombre.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Para el monto inicial digite solo numeros: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _owner.SaldoInicial = Convert.ToDecimal(this.txtNombre.Text);
                _owner.RealizaAperturaCaja();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar la apertura a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Apertura_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }
    }
}
