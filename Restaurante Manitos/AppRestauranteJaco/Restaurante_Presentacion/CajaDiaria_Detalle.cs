using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_Presentacion
{
    public partial class CajaDiaria_Detalle : Form
    {
        CajaDiaria_Mod _owner;

        Restaurante_BL.Movimiento objMovimiento = new Restaurante_BL.Movimiento();

        Restaurante_BL.Gastos objGastos = new Restaurante_BL.Gastos();

        public int Movimiento = 0;
        public string Comprobante = string.Empty;
        public string Descripcion = string.Empty;
        public string Monto = string.Empty;
        public string Saldo = string.Empty;
        public string Fecha = string.Empty;
        public string Hora = string.Empty;
        public int AutorizadoPor = 0;
        public string FacturaCompra = string.Empty;


        public CajaDiaria_Detalle(CajaDiaria_Mod owner)
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

        private void CajaDiaria_Detalle_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void CajaDiaria_Detalle_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objMovimiento.ObtieneMovimientos(this.cmbMovimientos);

                this.objGastos.ObtieneUsuarios(this.cmbAutoriza);

                //Detalle.Movimiento = this.dgvDatos.CurrentRow.Cells[0].ToString();
                //Detalle.Comprobante = this.dgvDatos.CurrentRow.Cells[1].ToString();
                //Detalle.Descripcion = this.dgvDatos.CurrentRow.Cells[2].ToString();
                //Detalle.Monto = this.dgvDatos.CurrentRow.Cells[3].ToString();
                //Detalle.Saldo = this.dgvDatos.CurrentRow.Cells[4].ToString();
                //Detalle.AutorizadoPor = this.dgvDatos.CurrentRow.Cells[5].ToString();
                //Detalle.Fecha = this.dgvDatos.CurrentRow.Cells[6].ToString();
                //Detalle.Hora = this.dgvDatos.CurrentRow.Cells[7].ToString();   
                if (AutorizadoPor == 0)
                {
                    this.cmbAutoriza.Visible = false;
                }
                else
                {
                    this.cmbAutoriza.SelectedValue = AutorizadoPor;
                }

                this.cmbMovimientos.SelectedValue = Movimiento;
                this.txtComprobante.Text = Comprobante;
                this.txtDescripcion.Text = Descripcion;
                this.txtMonto.Text = Monto;
                this.txtSaldo.Text = Saldo;
                this.dtpFecha.Value = Convert.ToDateTime(Fecha);
                this.txtHora.Text = Hora;

                if (Movimiento == 3 && Monto == Convert.ToDecimal("0").ToString("F"))//compra
                {
                    this.chkCheque.Visible = true;
                    this.chkCheque.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
