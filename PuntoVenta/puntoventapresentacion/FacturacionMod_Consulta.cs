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
    public partial class FacturacionMod_Consulta : Form
    {
        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        Facturacion_Mod _owner;

        Compras_Mantenimiento _owner2;

        public int accion = 0;
        public bool escompra = false;
        public int ProveedorId = 0;
    
        
        public FacturacionMod_Consulta(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public FacturacionMod_Consulta(Compras_Mantenimiento owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
        }
        private void FacturacionMod_Consulta_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);    
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.dgvDatos.Rows.Clear();

                    //try
                    //{
                    //    Int64 x = Convert.ToInt64(this.txtCodigo.Text);
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Para la búsqueda ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    this.txtCodigo.Text = string.Empty;
                    //}
                    if (this.txtCodigo.Text.Contains('r'))
                    {
                        this.txtCodigo.Text = string.Empty;
                        return;
                    }
                    if (this.txtCodigo.Text.Length == 0)
                    {
                        this.txtCodigo.Text = string.Empty;
                        return;
                    }

                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }


                    if (accion==0)
                    {
                        if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text,this.dgvDatos) == false)
                        {
                            this.txtCodigo.Text = string.Empty;
                            return;
                        }

                        //this.dgvDatos.Rows.Add(this.objFacturar.Codigo.ToString(),
                        //this.objFacturar.Descripcion.ToString(),
                        //this.objFacturar.PrecioIVA.ToString(),
                        //this.objFacturar.Existencias.ToString(),
                        //Math.Round(Convert.ToDecimal(Convert.ToDecimal(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                        //this.objFacturar.TipoPrecio.ToString()
                        //);
                    }

                    if (accion==2)
                    {

                        this.objFacturar.ProveedorId = ProveedorId;

                        if (this.objFacturar.ObtieneProductoCompras(this.txtCodigo.Text,this.dgvDatos) == false)
                        {
                            this.txtCodigo.Text = string.Empty;
                            return;
                        }

                        //this.dgvDatos.Rows.Add(this.objFacturar.Codigo.ToString(),
                        //this.objFacturar.Descripcion.ToString(),
                        //this.objFacturar.Precio.ToString(),
                        //this.objFacturar.Existencias.ToString(),
                        //Math.Round(Convert.ToDecimal(Convert.ToDecimal(this.objFacturar.Precio.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                        //this.objFacturar.TipoPrecio.ToString()
                        //);
                    }

                    this.txtCodigo.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar consultar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                this.btnAgregar.PerformClick();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F2)
            {
                this.txtCodigo.Focus();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F9)
            {
                this.btnCerrar.PerformClick();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;    // indicate that you handled this keystroke
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != (Keys.Enter))
                {
                    if (this.txtNombre.Text.Length==0)
                    {
                        this.dgvDatos.Rows.Clear();
                        return;
                    }

                    this.dgvDatos.Rows.Clear();

                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }

                    this.objFacturar.Descripcion = this.txtNombre.Text;

                    if (accion==0)
                    {
                        if (this.objFacturar.ObtieneProducto(this.dgvDatos) == false)
                        {
                            return;
                        }

                        //this.dgvDatos.Rows.Add(this.objFacturar.Codigo.ToString(),
                        //                        this.objFacturar.Descripcion.ToString(),
                        //                        this.objFacturar.PrecioIVA.ToString(),
                        //                        this.objFacturar.Existencias.ToString(),
                        //                        Math.Round(Convert.ToDecimal(Convert.ToDecimal(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                        //                        this.objFacturar.TipoPrecio.ToString()
                        //                        );
                    }

                    if (accion==2)
                    {
                        this.objFacturar.ProveedorId = ProveedorId;

                        
                        if (this.objFacturar.ObtieneProductoCompras(this.dgvDatos) == false)
                        {
                            return;
                        }

                        //this.dgvDatos.Rows.Add(this.objFacturar.Codigo.ToString(),
                        //                        this.objFacturar.Descripcion.ToString(),
                        //                        this.objFacturar.Precio.ToString(),
                        //                        this.objFacturar.Existencias.ToString(),
                        //                        Math.Round(Convert.ToDecimal(Convert.ToDecimal(this.objFacturar.Precio.ToString()) * Convert.ToDecimal(1)), 0, MidpointRounding.AwayFromZero),
                        //                        this.objFacturar.TipoPrecio.ToString()
                        //                        );                        
                    }

                    e.Handled = true;

                    //e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar consultar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count>0)
                {
                    if (escompra == false)
                    {
                        if (Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[3].Value.ToString()) < _owner.cantcompra)
                        {
                            MessageBox.Show("Solo existen " + this.dgvDatos.CurrentRow.Cells[3].Value.ToString() + " existencias sobre este articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (accion==0)
                    {
                        this._owner.CodigoS = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                        this._owner.ListaPreciosS = this.cmbListaPrecios.Text;
                        this._owner.AgregaLineaConsulta(sender, e);

                        this.Close();
                    }
                    if (accion==2)
                    {
                        this._owner2.CodigoS = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                        this._owner2.ListaPreciosS = this.cmbListaPrecios.Text;
                        this._owner2.AgregaLineaConsulta(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void FacturacionMod_Consulta_Load(object sender, EventArgs e)
        {
            this.cmbListaPrecios.Text = "Lista de precios 1";
            
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
