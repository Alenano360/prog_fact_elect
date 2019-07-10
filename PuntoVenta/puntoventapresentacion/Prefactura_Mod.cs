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
    public partial class Prefactura_Mod : Form
    {
        Facturacion_Mod _owner;

        PuntoVentaBL.Prefactura objPrefactura = new PuntoVentaBL.Prefactura();

        public Prefactura_Mod(Facturacion_Mod owner)
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = this.txtBuscar;

                this.objPrefactura.ObtienePrefacturas(this.dgvDatos);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar las prefacturas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.objPrefactura.Sbusqueda = this.txtBuscar.Text;

                    this.objPrefactura.ObtienePrefacturas(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las prefacturas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    this.objPrefactura.Orden = this.cmbOrdenar.Text;

                    this.objPrefactura.ObtienePrefacturas(this.dgvDatos);
                }
                else
                {
                    this.btnVer.PerformClick();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione la prefactura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la prefactura?", "Confirmation", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objPrefactura.Id = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value);

                        this.objPrefactura.EliminaPrefactura();

                        this.btnVer.PerformClick();

                        this.dgvDatos.Rows.Clear();

                        this.objPrefactura.ObtienePrefacturas(this.dgvDatos);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la prefactura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea mostrar la prefactura?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    VerDetalle form1 = new VerDetalle(this);
                    form1.TopLevel = false;
                    form1.Parent = this;
                    form1.comprobante = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    form1.cliente = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    form1.fecha = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    form1.hora = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                    form1.total = this.dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    form1.vendedor = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();
                    form1.impuesto = this.dgvDatos.CurrentRow.Cells[7].Value.ToString();
                    form1.descuento = this.dgvDatos.CurrentRow.Cells[8].Value.ToString();
                    form1.Prefactura = 1;

                    form1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Prefactura_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ActiveControl = this.txtBuscar;

                this.objPrefactura.ObtienePrefacturas(this.dgvDatos);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de prefacturas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Prefactura_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btnAceptar.PerformClick();
            }
            catch (Exception)
            {

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la prefactura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea mostrar la prefactura?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _owner.PrefacturaMostrar = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value);

                    _owner.cajeroidtemp = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[6].Value.ToString());

                    _owner.cajeronombretemp = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();

                    _owner.MuestraPrefactura();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
