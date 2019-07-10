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
    public partial class Proveedor_Mod : Form
    {
        Sel_Mod _owner;

        PuntoVentaBL.Proveedores objProveedor = new PuntoVentaBL.Proveedores();

        public Proveedor_Mod(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor_Mantenimiento Mantenimiento = new Proveedor_Mantenimiento(this);
            Mantenimiento.TopLevel = false;
            Mantenimiento.Parent = this;
            Mantenimiento.Accion = 1;
            Mantenimiento.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Proveedor_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objProveedor.ObtieneProveedores(this.dgvDatos);

                this.txtBuscar.Text = string.Empty;

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    Proveedor_Mantenimiento Mantenimiento = new Proveedor_Mantenimiento(this);
                    Mantenimiento.TopLevel = false;
                    Mantenimiento.Parent = this;
                    Mantenimiento.ProveedorId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    Mantenimiento.Accion = 2;
                    Mantenimiento.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Proveedor_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor_Reportes rep = new Proveedor_Reportes(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnModificar.PerformClick();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.objProveedor.Nombre = this.txtBuscar.Text;

                    this.objProveedor.ObtieneProveedoresBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text == "--Seleccione--")
                {
                    this.objProveedor.ObtieneProveedores(this.dgvDatos);
                }
                else
                {
                    this.objProveedor.ObtieneProveedoresOrdenado(this.dgvDatos, this.cmbOrdenar.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.objProveedor.ObtieneProveedores(this.dgvDatos);

                this.txtBuscar.Text = string.Empty;

                this.txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el proveedor?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            this.objProveedor.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                            this.objProveedor.EliminaProveedor(Login.UserId);

                            this.Proveedor_Mod_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}