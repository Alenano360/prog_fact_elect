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
    public partial class Cliente_Mod : Form
    {
        Sel_Mod _owner;

        PuntoVentaBL.Cliente objCliente = new PuntoVentaBL.Cliente();

        public Cliente_Mod(Sel_Mod owner)
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

        private void Cliente_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);    
        }

        public void Cliente_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objCliente.ObtieneClientes(this.dgvDatos);
                
                this.txtBuscar.Text = string.Empty;

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {                 
                    this.objCliente.Nombre = this.txtBuscar.Text;

                    this.objCliente.ObtieneClienteBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text == "--Seleccione--")
                {
                    this.objCliente.ObtieneClientes(this.dgvDatos);
                }
                else
                {
                    this.objCliente.ObtieneProductoClienteOrdenada(this.dgvDatos, this.cmbOrdenar.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.objModulo.ObtieneCajaDiaria()==false)
                //{
                //    return;
                //}
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

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    Cliente_Mantenimiento Mantenimiento = new Cliente_Mantenimiento(this);
                    Mantenimiento.TopLevel = false;
                    Mantenimiento.Parent = this;
                    Mantenimiento.Accion = 2;
                    Mantenimiento.ClienteId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    Mantenimiento.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.objModulo.ObtieneCajaDiaria() == false)
                //{
                //    return;
                //}
                if (this.dgvDatos.SelectedRows.Count>0)
                {
                    Cliente_Mantenimiento Mantenimiento = new Cliente_Mantenimiento(this);
                    Mantenimiento.TopLevel = false;
                    Mantenimiento.Parent = this;
                    Mantenimiento.Accion = 2;
                    Mantenimiento.ClienteId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    Mantenimiento.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    if (this.dgvDatos.CurrentRow.Cells[1].Value.ToString() == "CLIENTE" && this.dgvDatos.CurrentRow.Cells[2].Value.ToString() == "CONTADO")
                    {
                        return;
                    }
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el cliente?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            this.objCliente.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                            this.objCliente.EliminaCliente(Login.UserId);

                            this.Cliente_Mod_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.objCliente.ObtieneClientes(this.dgvDatos);

                this.txtBuscar.Text = string.Empty;

                this.txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes_Reportes rep = new Clientes_Reportes(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReciboCliente rec = new ReciboCliente(this);
            rec.TopLevel = false;
            rec.Parent = this;
            rec.Show();
        }

    }
}
