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
    public partial class CajaDiaria_Mantenimiento : Form
    {
        CajaDiaria_Mod _owner;

        Restaurante_BL.Movimiento objMovimiento = new Restaurante_BL.Movimiento();

        Restaurante_BL.CajaDiaria objCajaDiaria = new Restaurante_BL.CajaDiaria();

        Restaurante_BL.Gastos objGastos = new Restaurante_BL.Gastos();

        public int AutorizaId = 0;

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

                this.objGastos.ObtieneUsuarios(this.cmbAutoriza);
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
                if (Convert.ToInt32(this.cmbMovimientos.SelectedValue.ToString()) == 9)//gasto
                {
                    this.objGastos.Fecha = Convert.ToDateTime(this.dtpFecha.Value.ToShortDateString());
                    this.objGastos.Descripcion = this.txtDescripcion.Text;
                    this.objGastos.Monto = Convert.ToDecimal(this.txtMonto.Text);
                    if (this.txtComprobante.Text.Length != 0)
                    {
                        this.objGastos.ComprobanteId = Convert.ToInt64(this.txtComprobante.Text);
                    }
                    this.objGastos.AutorizaId = Convert.ToInt32(this.cmbAutoriza.SelectedValue.ToString());

                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el gasto?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objGastos.Hora = System.DateTime.Now.ToShortTimeString();

                        if (this.objGastos.AgregaGasto(Login.UserId))
                        {
                            MessageBox.Show("Gasto agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.Close();
                    }
                    
                }
                else
                {
                    this.objCajaDiaria.MovimientoId = Convert.ToInt32(this.cmbMovimientos.SelectedValue.ToString());

                    this.objCajaDiaria.Monto = Convert.ToDecimal(this.txtMonto.Text);

                    this.objCajaDiaria.Fecha = Convert.ToDateTime(this.dtpFecha.Value.ToShortDateString());

                    this.objCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();

                    this.objCajaDiaria.Descripcion = this.txtDescripcion.Text;

                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el movimiento de caja diaria?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objCajaDiaria.AgregaMovimiento(Login.UserId);

                        MessageBox.Show("Movimiento de caja diaria agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbMovimientos.SelectedValue.ToString()=="9")
                {
                    this.txtComprobante.Enabled = true;
                    this.cmbAutoriza.Enabled = true;
                    this.btnBuscaUsuario.Enabled = true;
                }
                else
                {
                    this.txtComprobante.Enabled = false;
                    this.cmbAutoriza.Enabled = false;
                    this.btnBuscaUsuario.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Usuario usuarios = new Sel_Usuario(this);
                usuarios.TopLevel = false;
                usuarios.tipo = 0;
                usuarios.Parent = this;
                usuarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaUsuario()
        {
            try
            {
                this.cmbAutoriza.SelectedValue = AutorizaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
