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
    public partial class NotaCredito_Pago : Form
    {
        Facturacion_Pago _owner;

        PuntoVentaBL.NotaCredito objNotaCredito = new PuntoVentaBL.NotaCredito();

        public List<string> ListaNotasCredito = new List<string>();

        public NotaCredito_Pago(Facturacion_Pago owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.dgvDatos.Columns["Sel"].Index && e.RowIndex >= 0)
            {
                bool Actual = Convert.ToBoolean(this.dgvDatos.CurrentRow.Cells[10].Value);

                if (Actual==true)
                {
                    Actual = false;
                    this.dgvDatos.CurrentRow.Cells[10].Value = Actual;
                    return;
                }
                if (Actual == false)
                {
                    Actual = true;
                    this.dgvDatos.CurrentRow.Cells[10].Value = Actual;
                    return;
                }
            }

        }

        public void CalculaTotal()
        {
            try
            {
                decimal total = 0;

                this.ListaNotasCredito.Clear();

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[10].Value)==true)
                    {
                        total+=Convert.ToDecimal(item.Cells[4].Value.ToString());

                        this.ListaNotasCredito.Add(item.Cells[0].Value.ToString());
                    }
                }

                this.txtTotal.Text = total.ToString("##,#0.#0");
            }
            catch (Exception)
            {                
            }
        }

        private void NotaCredito_Pago_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objNotaCredito.ObtieneNotasCreditoActivas(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las notas de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotaCredito_Pago_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalculaTotal();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.ListaNotasCredito = this.ListaNotasCredito;

                _owner.MontoNotasCredito = Convert.ToDecimal(this.txtTotal.Text);

                _owner.CambiaNotaCreditoMonto();

                this.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
