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
    public partial class Sel_Proveedor : Form
    {
        Inventario_Mantenimiento _owner;

        Proveedor_Reportes _owner2;

        Ventas_Reportes _owner3;

        Compras_Mod _owner4;

        Compras_Mantenimiento _owner5;

        Compras_Reportes _owner6;

        public int tipo = 0;

        PuntoVentaBL.Proveedores objProveedores = new PuntoVentaBL.Proveedores();

        public Sel_Proveedor(Inventario_Mantenimiento owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Sel_Proveedor(Proveedor_Reportes owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        public Sel_Proveedor(Ventas_Reportes owner)
        {
            InitializeComponent();

            _owner3 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
        }

        public Sel_Proveedor(Compras_Mod owner)
        {
            InitializeComponent();

            _owner4 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing4);
        }

        public Sel_Proveedor(Compras_Mantenimiento owner)
        {
            InitializeComponent();

            _owner5 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing5);
        }

        public Sel_Proveedor(Compras_Reportes owner)
        {
            InitializeComponent();

            _owner6 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing6);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
        }

        private void Form2_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this._owner3.Show();
        }

        private void Form2_FormClosing4(object sender, FormClosingEventArgs e)
        {
            this._owner4.Show();
        }
        private void Form2_FormClosing5(object sender, FormClosingEventArgs e)
        {
            this._owner5.Show();
        }
        private void Form2_FormClosing6(object sender, FormClosingEventArgs e)
        {
            this._owner6.Show();
        }
        private void Sel_Proveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objProveedores.ObtieneProveedores(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDatos.Columns[0].Visible = true;
            if (this.tipo==0)
            {
                _owner.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner.CambiaProveedor();
            }
            if (this.tipo==1)
            {
                _owner2.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner2.CambiaProveedor();  
            }
            if (this.tipo ==3)
            {
                _owner3.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner3.CambiaProveedor();
            }
            if (this.tipo == 4)
            {
                _owner4.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner4.CambiaProveedor();
                _owner4.ObtieneFacturas();
            }
            if (this.tipo == 5)
            {
                _owner5.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner5.CambiaProveedor();
            }
            if (this.tipo == 6)
            {
                _owner6.ProveedorId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner6.CambiaProveedor();
            }
            dgvDatos.Columns[0].Visible = false;

            this.Close();
        }

        private void Sel_Proveedor_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (this.txtBuscar.Text=="")
                    {
                        this.objProveedores.ObtieneProveedores(this.dgvDatos);

                        return;
                    }
                    this.objProveedores.Nombre = this.txtBuscar.Text;

                    this.objProveedores.ObtieneProveedoresBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.txtBuscar.Text == "")
                    {
                        this.objProveedores.ObtieneProveedores(this.dgvDatos);

                        return;
                    }
                    this.objProveedores.Nombre = this.txtBuscar.Text;

                    this.objProveedores.ObtieneProveedoresBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled=true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
