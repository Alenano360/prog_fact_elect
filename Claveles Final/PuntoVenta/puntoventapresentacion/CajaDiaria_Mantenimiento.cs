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
    public partial class CajaDiaria_Mantenimiento : Form
    {
        CajaDiaria_Mod _owner;

        PuntoVentaBL.Movimiento objMovimiento = new PuntoVentaBL.Movimiento();

        PuntoVentaBL.CajaDiaria objCajaDiaria = new PuntoVentaBL.CajaDiaria();

        PuntoVentaBL.ImpresionMovimientoCajaDiaria objImpresionCaja = new PuntoVentaBL.ImpresionMovimientoCajaDiaria();

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        public CajaDiaria_Mantenimiento(CajaDiaria_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.CajaDiaria_Mod_Load(sender, e);
            this._owner.Show();
        }

        private void CajaDiaria_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objMovimiento.ObtieneMovimientosMantenimiento(this.cmbMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al mantenimiento de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CajaDiaria_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);    
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtMonto.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Digite números en la casilla de monto!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.objCajaDiaria.MovimientoId = Convert.ToInt32(this.cmbMovimientos.SelectedValue.ToString());

                this.objCajaDiaria.Monto = Convert.ToDecimal(this.txtMonto.Text);

                this.objCajaDiaria.Fecha = Convert.ToDateTime(this.dtpFecha.Value.ToShortDateString());

                this.objCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();

                this.objCajaDiaria.Descripcion = this.txtDescripcion.Text;

                this.objCajaDiaria.AgregaMovimiento(Login.UserId);

                if (DialogResult.Yes==MessageBox.Show("¿Desea imprimir el movimiento de caja diaria?","Validación",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                {
                    this.objImpresionCaja.Fecha = this.dtpFecha.Value;

                    this.objImpresionCaja.Monto = Convert.ToDecimal(this.txtMonto.Text);

                    this.objImpresionCaja.Concepto = this.txtDescripcion.Text;

                    this.objImpresionCaja.Movimiento = this.cmbMovimientos.Text;

                    this.objImpresionCaja.Usuario = Login.LoginUsuarioFinal;

                    this.objImpresionCaja.print();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
