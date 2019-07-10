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
    public partial class Sel_Cliente : Form
    {

        Facturacion_Mod _owner;

        
        Ventas_Mod _owner2;

        Ventas_Reportes _owner3;

        public int tipo = 0;

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Cliente objCliente = new PuntoVentaBL.Cliente();
  
       
        public Sel_Cliente(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Sel_Cliente(Ventas_Mod owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        public Sel_Cliente(Ventas_Reportes owner)
        {
            InitializeComponent();

            _owner3 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
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

        public void Sel_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objCliente.ObtieneClientes(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargaClientes()
        {
            try
            {
                this.BringToFront();

                this.objCliente.ObtieneClientes(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDatos.Columns[0].Visible = true;
            if (tipo == 0)//facturacionMod
            {

                _owner.ClienteN = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner.CambiaCliente();
                this.dgvDatos.Columns[0].Visible = false;
            }
            if (tipo == 1)//ventas mod
            {

                _owner2.ClienteId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner2.CambiaCliente();
                _owner2.ObtieneFacturasCliente();
                this.dgvDatos.Columns[0].Visible = false;
            }

            if (tipo ==3)//ventas reportes
            {

                _owner3.ClienteId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                //_owner3.CambiaCliente();                
                this.dgvDatos.Columns[0].Visible = false;
            }
            this.dgvDatos.Columns[0].Visible = false;
            this.Close();
        }

        private void Sel_Familia_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    this.objInventario.Descripcion = this.txtBuscar.Text;

                    this.objInventario.ObtieneClienteBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente_Mantenimiento Mantenimiento = new Cliente_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 1;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al mantenimiento de los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


