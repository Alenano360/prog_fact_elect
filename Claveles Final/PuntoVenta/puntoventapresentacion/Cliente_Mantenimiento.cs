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
    public partial class Cliente_Mantenimiento : Form
    {        
        public int Accion = 0;

        public int ClienteId = 0;

        decimal Monto = 0;

        int Columna = 3;//Casilla Selección

        Cliente_Mod _owner;

        Sel_Cliente _owner2;

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        PuntoVentaBL.ImpresionMovimientoSaldo objSaldo = new PuntoVentaBL.ImpresionMovimientoSaldo();

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

       

        public Cliente_Mantenimiento(Cliente_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Cliente_Mantenimiento(Sel_Cliente owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Cliente_Mod_Load(sender, e);

            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
            this._owner2.CargaClientes();            
        }

        private void Cliente_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Accion==2)//modificar
                {
                    this.objcliente.Id = ClienteId;

                    this.objcliente.ObtieneClienteBusqueda();

                    this.txtNombre.Text = this.objcliente.Nombre;
                    this.txtApellidos.Text = this.objcliente.Apellido;
                    this.txtCedula.Text = this.objcliente.Cedula.ToString();
                    this.txtContacto.Text = this.objcliente.Contacto.ToString();
                    this.txtTelefono1.Text = this.objcliente.Telefono1.ToString();
                    this.txtTelefono2.Text = this.objcliente.Telefono2.ToString();
                    this.txtSaldoActual.Text = this.objcliente.Saldo.ToString("F");
                    this.txt_limite.Text = this.objcliente.limite_credito.ToString();


                    this.objFacturar.ObtieneFacturaCliente(ClienteId, this.dgvDatos);

                    //cargar historial
                    this.objFacturar.ObtieneHistoricoPagos(this.txtNombre.Text, this.txtApellidos.Text
                        ,this.dvg_historial);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validacion()
        {
            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el nombre del cliente!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            //if (this.txtCedula.Text.Length == 0)
            //{
            //    MessageBox.Show("Por favor ingrese la cédula del cliente!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtCedula.Focus();
            //    return false;
            //}
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validacion())
                {
                    return;
                }
                if (Convert.ToDecimal(this.txtAgregarSaldo.Text)>0)
                {                    
                    if (this.Accion == 2 && MessageBox.Show("Desea imprimir el comprobante de ingreso de saldo?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)//modificar
                    {
                        this.objSaldo.Monto = Convert.ToDecimal(this.txtAgregarSaldo.Text);
                        
                        this.objSaldo.Saldo = Convert.ToDecimal(this.txtSaldoActual.Text);

                        this.objcliente.Id = ClienteId;

                        this.objcliente.ObtieneClienteBusqueda();

                        this.objSaldo.ClienteS = this.objcliente.Nombre + " " + this.objcliente.Apellido;

                        this.objSaldo.Usuario = Login.LoginUsuarioFinal;
                        //aqui voy 
                        this.objcliente.actualizar_limite_credito(txtNombre.Text, txtApellidos.Text, txt_limite.Text);
                        

                        this.objSaldo.print();

                    }
                    if (this.objModulo.ObtieneCajaDiaria() == false)
                    {
                        
                        return;
                    }  
                }


                this.objcliente.Nombre = this.txtNombre.Text;
                this.objcliente.Apellido = this.txtApellidos.Text;
                this.objcliente.Contacto = this.txtContacto.Text;
                this.objcliente.Cedula = this.txtCedula.Text;
                this.objcliente.Telefono1 = this.txtTelefono1.Text;
                this.objcliente.Telefono2 = this.txtTelefono2.Text;
                this.objcliente.Saldo = Convert.ToDecimal(this.txtSaldoActual.Text) + Convert.ToDecimal(this.txtAgregarSaldo.Text);

                if (Accion==1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el cliente?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {                        
                        if (this.objcliente.AgregaCliente(Login.UserId))
                        {
                            MessageBox.Show("Cliente agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.objcliente.actualizar_limite_credito(txtNombre.Text, txtApellidos.Text, txt_limite.Text);
                        }

                        this.Close();
                    } 
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el cliente?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {

                        this.objcliente.Id = this.ClienteId;

                        this.objcliente.Saldo2 = Convert.ToDecimal(this.txtAgregarSaldo.Text);

                        if (this.objcliente.ModificaCliente(Login.UserId))
                        {
                            if (dgvDatos.Rows.Count > 0)
                            {
                                dgvDatos.ClearSelection();

                                dgvDatos.CurrentCell = dgvDatos.Rows[0].Cells[3];

                                for (int i = 0; i < dgvDatos.Rows.Count; i++)
                                {
                                    if ((this.dgvDatos[Columna, i].Value) != null && ((bool)this.dgvDatos[Columna, i].Value == true))
                                    {
                                        Int64 IdFactura =Convert.ToInt64 ( dgvDatos[0, i].Value);
                                        this.objFacturar.ActualizaEstadoFactura(IdFactura, this.objcliente.Id);
                                    }
                                }
                            }
                            MessageBox.Show("Cliente modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.objcliente.actualizar_limite_credito(txtNombre.Text, txtApellidos.Text, txt_limite.Text);
                        }

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Cliente_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnMostrarFacturas_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatos.Rows.Count > 0)
                {
                    Monto = decimal.Parse(txtAgregarSaldo.Text);

                    if ((bool)this.dgvDatos[e.ColumnIndex, e.RowIndex].Value == true)
                    {

                        Monto = Monto + decimal.Parse(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value.ToString());

                    }
                    else if ((bool)this.dgvDatos[e.ColumnIndex, e.RowIndex].Value == false)
                    {
                        Monto = Monto - decimal.Parse(dgvDatos.Rows[dgvDatos.CurrentCell.RowIndex].Cells["Total"].Value.ToString());
                    }
                    txtAgregarSaldo.Text = Monto.ToString();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Hubo un inconveniente al sumar el saldo: " + ex.Message, "Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnDesmarcarCasillas_Click(object sender, EventArgs e)
        {
            try
            {
                             
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {

                    if (Convert.ToBoolean(item.Cells[3].Value) == true)
                    {
                        item.Cells[3].Value = false;
                    }
                    else
                        item.Cells[3].Value = true;
                   


                }
                //if (dgvDatos.Rows.Count > 0)
                //{
                //    dgvDatos.ClearSelection();

                //    dgvDatos.CurrentCell = dgvDatos.Rows[0].Cells[3];

                //    for (int i = 0; i < dgvDatos.Rows.Count; i++)
                //    {
                //        if ((this.dgvDatos[Columna, i].Value)!=null && ((bool)this.dgvDatos[Columna, i].Value == true))
                //        {
                //            dgvDatos.CurrentCell = dgvDatos.Rows[i].Cells[3];
                //            dgvDatos[Columna, i].Value = false;
                //        }
                //    }
                //}
            }
             catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al sumar el saldo: " + ex.Message, "Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIgnorarFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea Ignorar Estas Facturas?", "Confirmación", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        dgvDatos.ClearSelection();

                        dgvDatos.CurrentCell = dgvDatos.Rows[0].Cells[3];

                        //for (int i = 0; i < dgvDatos.Rows.Count; i++)
                        //{
                        //    if ((this.dgvDatos[Columna, i].Value) != null && ((bool)this.dgvDatos[Columna, i].Value == true))
                        //    {
                        //        dgvDatos.CurrentCell = dgvDatos.Rows[i].Cells[3];
                        //        dgvDatos[Columna, i].Value = false;
                        //    }
                        //    Int64 IdFactura = Convert.ToInt64(dgvDatos[0, i].Value);
                        //    this.objFacturar.ActualizaEstadoFactura(IdFactura, this.objcliente.Id);
                        //}
                        foreach (DataGridViewRow item in this.dgvDatos.Rows)
                        {

                            if (Convert.ToBoolean(item.Cells[3].Value) == true)
                            {
                                Int64 IdFactura = Convert.ToInt64(item.Cells[0].Value);
                                 this.objFacturar.ActualizaEstadoFactura(IdFactura, this.objcliente.Id);

                                 this.objFacturar.FacturaId = IdFactura;
                                 this.objFacturar.AnulaFactura(this.objcliente.Id);
                                

                            }
                        }


                        this.dgvDatos.Rows.Clear();
                        this.objFacturar.ObtieneFacturaCliente(ClienteId, this.dgvDatos);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ignorar las facturas: " + ex.Message, "Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
