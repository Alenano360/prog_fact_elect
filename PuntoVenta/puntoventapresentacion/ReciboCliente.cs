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
    public partial class ReciboCliente : Form
    {
        Cliente_Mod _owner;
        PuntoVentaBL.ReciboClientes objRecibo = new PuntoVentaBL.ReciboClientes();
        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();
        PuntoVentaBL.TicketRecibo objTicket = new PuntoVentaBL.TicketRecibo();

        public ReciboCliente(Cliente_Mod owner)
        {
            InitializeComponent();
            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
        private void ReciboCliente_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
             

            Recibos_Mantenimiento Mantenimiento = new Recibos_Mantenimiento(this);
            Mantenimiento.TopLevel = false;
            Mantenimiento.Parent = this;
            Mantenimiento.Accion = 1;
            Mantenimiento.Show();


            //Para realizar abonos, seleccionar primero el cliente
            int valor = Convert.ToInt32(this.cmbCliente.SelectedValue);
            if (valor != 1 && valor != 0)
            {
                Recibos_Mantenimiento Mantenimiento2 = new Recibos_Mantenimiento(this);
                Mantenimiento2.TopLevel = false;
                Mantenimiento2.Parent = this;
                Mantenimiento2.ClienteId = valor;
                Mantenimiento2.Cuenta = Convert.ToString(this.dgvDatos.CurrentRow.Cells[10].Value.ToString());
                Mantenimiento2.Accion = 3;
                Mantenimiento2.Show();
            }    
        }

        public void ReciboCliente_Load(object sender, EventArgs e)
        {
            
            this.objRecibo.ObtieneReciboClientes(dgvDatos);

            this.objcliente.ObtieneClientes(this.cmbCliente);
          
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Recibos_Mantenimiento Mantenimiento = new Recibos_Mantenimiento(this);
            Mantenimiento.TopLevel = false;
            Mantenimiento.Parent = this;
            Mantenimiento.ReciboId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
            Mantenimiento.Accion = 2;
            Mantenimiento.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             
                try
                {
                    if (Login.RolId.ToString() == "1")//solo admin puede ver
                    {
                        DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el recibo?", "Confirmación", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK)
                        {
                            if (this.dgvDatos.SelectedRows.Count > 0)
                            {
                                this.objRecibo.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                                this.objRecibo.EliminaRecibo();

                                this.ReciboCliente_Load(sender, e);
                            }
                        }

                    }
                 }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (txtBuscar.Text.Count() > 0)
                    {
                        this.objRecibo.Id = Convert.ToInt32(this.txtBuscar.Text);
                        this.objRecibo.Cuenta = Convert.ToString(this.txtBuscar.Text);
                        this.objRecibo.ObtieneReciboBusqueda(this.dgvDatos);

                        this.txtBuscar.Text = string.Empty;

                        e.Handled = true;

                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        this.ReciboCliente_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(this.cmbCliente.SelectedValue);
            if (valor == 1 || valor == 0)
            {
                this.ReciboCliente_Load(sender, e);
            }

            if (cmbEstado.Text == "INACTIVOS")
            {
                this.objRecibo.Activo = false;
            }
            else
                this.objRecibo.Activo = true;
            this.objRecibo.ClienteId = valor;

            this.objRecibo.ObtieneReciboBusqueda2(this.dgvDatos);
        }

        private void cmbCliente_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string estado = Convert.ToString(this.cmbEstado.Text);
            if (estado== "ACTIVOS")
            {
               this.objRecibo.ObtieneReciboClientes(dgvDatos);
            }
            else if (estado == "INACTIVOS")
            {
                this.objRecibo.ObtieneReciboClientes2(dgvDatos);
            }


        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Recibos_Mantenimiento Mantenimiento2 = new Recibos_Mantenimiento(this);
            Mantenimiento2.TopLevel = false;
            Mantenimiento2.Parent = this;
            Mantenimiento2.ClienteId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[11].Value.ToString());
            Mantenimiento2.Cuenta = Convert.ToString(this.dgvDatos.CurrentRow.Cells[10].Value.ToString());
            Mantenimiento2.Accion = 3;
            Mantenimiento2.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
             DialogResult result2 = MessageBox.Show("¿Desea reimprimir este recibo?", "Confirmación", MessageBoxButtons.OKCancel);
             if (result2 == DialogResult.OK)
             {
                 this.ReimprimeTicket();
             }
        }

        public void ReimprimeTicket()
        {
            try
            {

                this.objTicket.ReciboId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                this.objTicket.FechaCreacion = Convert.ToDateTime(this.dgvDatos.CurrentRow.Cells[9].Value.ToString());
                this.objTicket.ClienteNombre =Convert.ToString(this.dgvDatos.CurrentRow.Cells[1].Value.ToString());

                this.objcliente.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[11].Value.ToString());
                this.objcliente.ObtieneClienteBusqueda();
                this.objTicket.ClienteCedula = objcliente.Cedula;
                this.objTicket.TotalLetras = Convert.ToString(this.dgvDatos.CurrentRow.Cells[6].Value.ToString());
                this.objTicket.Total =Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[2].Value.ToString());
                this.objTicket.Concepto = Convert.ToString(this.dgvDatos.CurrentRow.Cells[7].Value.ToString());
                this.objTicket.SaldoAnterior = Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[3].Value.ToString());
                this.objTicket.Abono = Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[4].Value.ToString());
                this.objTicket.SaldoActual = Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[5].Value.ToString());
                if (Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[8].Value.ToString())==1)
                {
                    this.objTicket.TipoRecibo = "Efectivo";

                }
                else if (Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[8].Value.ToString()) == 2)
                {
                    this.objTicket.TipoRecibo = "Cheque";

                }
                this.objTicket.NumCuenta = Convert.ToString(this.dgvDatos.CurrentRow.Cells[10].Value.ToString());

                this.objTicket.print();

                this.objTicket.Offset = 40;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
