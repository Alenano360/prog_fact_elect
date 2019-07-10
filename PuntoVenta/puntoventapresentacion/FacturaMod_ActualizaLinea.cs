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
    public partial class FacturaMod_ActualizaLinea : Form
    {
        Facturacion_Mod _owner;

        Compras_Mantenimiento _owner2;

        public int accion = 0;

        public decimal iva = 0;

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();
           
        PuntoVentaDAL.CONEXIONDataContext db = new PuntoVentaDAL.CONEXIONDataContext();

        public void OpenConn()
        {
            if (db == null) db = new PuntoVentaDAL.CONEXIONDataContext();
        }

        public void CloseConn()
        {
            if (db != null)
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();

                db.Dispose();
                db = null;
            }
        }
      
        public FacturaMod_ActualizaLinea(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }


        public FacturaMod_ActualizaLinea(Compras_Mantenimiento owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this._owner.Facturacion_Mod_Load();
            this._owner.Show();
        }
        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Compras_Mantenimiento_Load();
            this._owner2.Show();
        }
        public string Codigo = string.Empty;
        public string Cantidad = string.Empty;
        public string ListaPrecios = string.Empty;
        public string Descripcion = string.Empty;
        public int unidadmedida = 0;
        public int TipoFactura = 0;
        public string precioconiv, porcdesc, descmonto = string.Empty;

        string iva1 = string.Empty;

        private void FacturaMod_ActualizaLinea_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();


            
                                  
                this.OpenConn();
            
                var bus = (from x in db.InformacionGeneral
                           select x);

        

                iva = (Convert.ToDecimal(bus.First().IVA)/100);

                iva1 ="1." + Convert.ToDecimal(bus.First().IVA).ToString("##");                

                this.txtCodigo.Text = Codigo;

                this.txtDescripcion.Text = Descripcion;

                this.nupCantidad.Text = Convert.ToDecimal(Cantidad).ToString();

                //this.nupCantidad.Visible = false;

                //if (unidadmedida == 1)
                //{
                //    this.nupCantidad.Visible = true;

                //    this.nupCantidad.Visible = false;
                //}

                this.nupCantidad.Text = Convert.ToDecimal(Cantidad).ToString("F");

                this.cmbListaPrecios.Text = ListaPrecios;

                this.txtPrecioIV.Text = Convert.ToDecimal(precioconiv).ToString("#0,#.#0");

                this.txtPorcDescuento.Text = Convert.ToDecimal(this.porcdesc).ToString("#0,#.#0");

                this.txtSubtotal.Text = Convert.ToDouble(Convert.ToDouble(precioconiv) * Convert.ToDouble(this.nupCantidad.Text)).ToString("#0,#.#0");

                this.txtDesc.Text=Convert.ToDecimal(this.descmonto).ToString("#0,#.#0");

                this.txtTotal.Text = (Convert.ToDecimal(this.txtSubtotal.Text) - Convert.ToDecimal(this.txtDesc.Text)).ToString("#0,#.#0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                if (accion == 0)
                {
                    _owner.CodigoS = this.txtCodigo.Text;

                    if (unidadmedida == 1)
                    {
                        _owner.CantidadS = this.nupCantidad.Text.ToString();
                    }
                    else
                    {
                        _owner.CantidadS = this.nupCantidad.Text;
                    }


                    _owner.precioivaactualiza = Convert.ToDecimal(this.txtPrecioIV.Text);

                    _owner.ListaPreciosS = this.cmbListaPrecios.Text;

                    _owner.porcdescactualiza = Convert.ToDecimal(this.txtPorcDescuento.Text);

                    _owner.descuentodescactualiza = Convert.ToDecimal(this.txtDesc.Text);

                    decimal temp = (Convert.ToDecimal(this.txtPrecioIV.Text));

                    decimal porcdes = 1;

                    if (Convert.ToDecimal(this.txtPorcDescuento.Text)>0)
                    {
                        porcdes = (100 - Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100;
                    }

                    _owner.totaldescactualiza = Convert.ToDecimal(temp * porcdes * Convert.ToDecimal(this.nupCantidad.Text));


                    if (TipoFactura == 1)
                    {
                        if (_owner.AgregaLineaExistente() == false)
                        {
                            return;
                        }
                    }
                    if (TipoFactura == 2)
                    {
                        if (_owner.AgregaLineaExistente2() == false)
                        {
                            return;
                        }
                    }
                }

                if (accion == 2)///compras mantenimiento
                {
                    _owner2.CodigoS = this.txtCodigo.Text;

                    if (unidadmedida == 1)
                    {
                        _owner2.CantidadS = this.nupCantidad.Text.ToString();
                    }
                    else
                    {
                        _owner2.CantidadS = this.nupCantidad.Text;
                    }

                    _owner2.ListaPreciosS = this.cmbListaPrecios.Text;

                    if (_owner2.AgregaLineaExistente() == false)
                    {
                        return;
                    }

                }


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FacturaMod_ActualizaLinea_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void nupCantidad_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.nupCantidad.Text)==0)
                {
                    this.nupCantidad.Text = "1.00";
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.nupCantidad.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Para la cantidad digite solo números", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.txtSubtotal.Text = (Convert.ToDecimal(this.txtPrecioIV.Text) * Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.cmbListaPrecios.Text == "Lista de precios 1")
            //    {
            //        this.objFacturar.TipoPrecio = 1;
            //    }
            //    else
            //    {
            //        this.objFacturar.TipoPrecio = 2;
            //    }

            //    if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
            //    {
            //        return;
            //    }

            //    if (this.objFacturar.MontoIV > 0)
            //    {
            //        decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text) / Convert.ToDecimal(this.iva1)));//precio sin iv

            //        decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

            //        this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Value)).ToString("#0,#.#0");

            //        this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");
            //    }
            //    else
            //    {
            //        decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text)));//precio sin iv

            //        decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

            //        this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Value)).ToString("#0,#.#0");

            //        this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");
            //    }
            //    //decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text) / Convert.ToDecimal(this.iva1)));//precio sin iv

            //    //decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

            //    //this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Value)).ToString("#0,#.#0");

            //    //this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtPorcDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal PorDes = 0;
                if (txtPorcDescuento.Text == "")
                    txtPorcDescuento.Text = "0.00";

                PorDes = Convert.ToDecimal(txtPorcDescuento.Text);

              
                

                if (this.cmbListaPrecios.Text == "Lista de precios 1")
                {
                    this.objFacturar.TipoPrecio = 1;
                }
                else
                {
                    this.objFacturar.TipoPrecio = 2;
                }

                if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                {
                    return;
                }

                if (this.objFacturar.MontoIV>0)
                {
                   decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text) / Convert.ToDecimal(this.iva1)));//precio sin iv

                    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                    this.txtDesc.Text = ((temp * porcdes)*Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

                    this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");                 
                }
                else
                {
                    decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text)));//precio sin iv

                    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                    this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

                    this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioIV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbListaPrecios.Text == "Lista de precios 1")
                {
                    this.objFacturar.TipoPrecio = 1;
                }
                else
                {
                    this.objFacturar.TipoPrecio = 2;
                }

                if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                {
                    return;
                }

                this.txtSubtotal.Text = (Convert.ToDecimal(this.txtPrecioIV.Text) * Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

                if (this.objFacturar.MontoIV > 0)
                {
                    decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text) / Convert.ToDecimal(this.iva1)));//precio sin iv

                    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                    this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

                    this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");
                }
                else
                {
                    decimal temp = ((Convert.ToDecimal(this.txtPrecioIV.Text)));//precio sin iv

                    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                    this.txtDesc.Text = ((temp * porcdes) * Convert.ToDecimal(this.nupCantidad.Text)).ToString("#0,#.#0");

                    this.txtTotal.Text = (Convert.ToDouble(this.txtSubtotal.Text) - Convert.ToDouble(this.txtDesc.Text)).ToString("#0,#.#0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
    
    

     
    }
}
