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
    public partial class VerDetalle : Form
    {
        Proforma_Mod _owner1;

        Prefactura_Mod _owner2;

        NotasCredito_Mod _owner3;

        Apartados_Mod _owner4;

        public string comprobante, fecha, hora, cliente, descuento, impuesto, vendedor, total,subtotal,cajero,fechaFinal,cobrado,saldo,FacturaId = string.Empty;

        public decimal Proforma,Prefactura,Nota,Apartado = 0;

        PuntoVentaBL.Proforma objProforma = new PuntoVentaBL.Proforma();

        PuntoVentaBL.Prefactura objPrefactura = new PuntoVentaBL.Prefactura();

        PuntoVentaBL.NotaCredito objNotaCredito = new PuntoVentaBL.NotaCredito();

        PuntoVentaBL.Apartados objApartado = new PuntoVentaBL.Apartados();

        PuntoVentaBL.ImpresionProforma objImpresionProforma = new PuntoVentaBL.ImpresionProforma();

        PuntoVentaBL.ImpresionPrefactura objImpresionPrefactura = new PuntoVentaBL.ImpresionPrefactura();

        PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        public VerDetalle(Proforma_Mod owner)
        {
            InitializeComponent();

            _owner1 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner1.Show();
        }

        public VerDetalle(Prefactura_Mod owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
        }

        public VerDetalle(NotasCredito_Mod owner)
        {
            InitializeComponent();

            _owner3 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
        }

        private void Form2_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this._owner3.Show();
        }

        public VerDetalle(Apartados_Mod owner)
        {
            InitializeComponent();

            _owner4 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing4);
        }

        private void Form2_FormClosing4(object sender, FormClosingEventArgs e)
        {
            this._owner4.Show();
        }

        private void VerDetalle_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void VerDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.txtCliente.Text = cliente;
                this.txtComprobante.Text = comprobante;
                this.txtDescuento.Text = descuento;
                this.txtFecha.Text = fecha;
                this.txtHora.Text = hora;
                this.txtImpuesto.Text = impuesto;
                this.txtTotal.Text = total;
                this.txtVendedor.Text = vendedor;
                this.dgvDatos.BringToFront();


                if (Prefactura==1)
                {
                    this.dgvDatos1.BringToFront();
                    this.objPrefactura.ComprobanteId = Convert.ToInt64(comprobante);
                    this.objPrefactura.ObtieneDetallePrefactura(this.dgvDatos1);
                    subtotal = this.objPrefactura.Subtotal.ToString();
                    cajero = this.objPrefactura.Cajero.ToString();
                }
                if (Proforma == 1)
                {
                    this.objProforma.ComprobanteId = Convert.ToInt64(comprobante);
                    this.objProforma.ObtieneDetalleProforma(this.dgvDatos);
                    subtotal = this.objProforma.Subtotal.ToString();                  
                    cajero = this.objProforma.Cajero.ToString();
                    
                }

                if (Apartado == 1)
                {
                    this.objApartado.AbonoId = Convert.ToInt64(comprobante);
                    this.objApartado.ObtieneDetalleApartado(this.dgvDatos);
                    subtotal = this.objApartado.Subtotal.ToString();
                    cajero = this.objApartado.Cajero.ToString();
                    this.lblFecha1.Text = "INICIO:";
                    this.lblHora.Text = "VENCIMIENTO:";
                    this.txtHora.Text = fechaFinal;
                }
                if (Nota==1)
                {
                    this.objNotaCredito.ComprobanteId = Convert.ToInt64(comprobante);
                    this.objNotaCredito.ObtieneDetalleNota(this.dgvDatos);
                    subtotal = this.objNotaCredito.Subtotal.ToString();
                    cajero = this.objNotaCredito.Cajero.ToString();

                    //this.btnImprimir.Visible = false;
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el detalle: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Nota==1)
                {
                    this.objTicket.Articulos.Clear();

                    this.objTicket.FacturaId = Convert.ToInt64(this.txtComprobante.Text);

                    this.objTicket.Fecha = Convert.ToDateTime(this.txtFecha.Text);

                    this.objTicket.Hora = this.txtHora.Text;

                    this.objTicket.ClienteNombre = this.txtCliente.Text;

                    this.objTicket.NotaCredito = 1;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {

                        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value)), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        this.objTicket.Articulos.Add(
                            item.Cells[3].Value.ToString() + ";" +
                            item.Cells[1].Value.ToString() + ";" +
                            //item.Cells[2].Value.ToString() + ";" +
                            //item.Cells[3].Value.ToString() + ";" +
                            //item.Cells[4].Value.ToString() + ";" +
                            totaliva.ToString("F")
                            );
                    }

                    this.objTicket.Impuesto = Convert.ToDecimal(impuesto);

                    this.objTicket.Desc_Aplicado = Convert.ToDecimal(descuento);

                    this.objTicket.TotalFactura = Convert.ToDecimal(total);

                    this.objTicket.subtotal = Convert.ToDecimal(subtotal) + Convert.ToDecimal(descuento);

                    this.objTicket.CajeroNombre = cajero.ToUpper().ToString();

                    this.objTicket.FacturaIdString = FacturaId;

                    this.objTicket.print();
                }
                if (Prefactura==1)
                {
                   this.objImpresionPrefactura.Articulos.Clear();

                    this.objImpresionPrefactura.FacturaId = Convert.ToInt64(this.txtComprobante.Text);

                    this.objImpresionPrefactura.Fecha = this.txtFecha.Text;

                    this.objImpresionPrefactura.ClienteNombre = this.txtCliente.Text;

                    foreach (DataGridViewRow item in this.dgvDatos1.Rows)
                    {
                        this.objImpresionPrefactura.Articulos.Add(
                            item.Cells[0].Value.ToString() + ";" +
                            item.Cells[1].Value.ToString() + ";" +
                            item.Cells[2].Value.ToString() + ";" +
                            item.Cells[3].Value.ToString() + ";" +
                            item.Cells[4].Value.ToString() + ";" +
                            item.Cells[5].Value.ToString() + ";" +
                            item.Cells[6].Value.ToString()//ubicacion
                            );
                    }

                    this.objImpresionPrefactura.Impuesto = Convert.ToDecimal(impuesto);

                    this.objImpresionPrefactura.Desc_Aplicado = Convert.ToDecimal(descuento);

                    this.objImpresionPrefactura.TotalFactura = Convert.ToDecimal(total);

                    this.objImpresionPrefactura.subtotal = Convert.ToDecimal(subtotal);

                    this.objImpresionPrefactura.CajeroNombre = cajero.ToUpper().ToString();

                    this.objImpresionPrefactura.print();
                }
                if (Proforma == 1)
                {
                    this.objImpresionProforma.Articulos.Clear();

                    this.objImpresionProforma.FacturaId = Convert.ToInt64(this.txtComprobante.Text);

                    this.objImpresionProforma.Fecha = this.txtFecha.Text;

                    this.objImpresionProforma.ClienteNombre = this.txtCliente.Text;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objImpresionProforma.Articulos.Add(
                            item.Cells[0].Value.ToString() + ";" +
                            item.Cells[1].Value.ToString() + ";" +
                            item.Cells[2].Value.ToString() + ";" +
                            item.Cells[3].Value.ToString() + ";" +
                            item.Cells[4].Value.ToString() + ";" +
                            item.Cells[5].Value.ToString()
                            );
                    }

                    this.objImpresionProforma.Impuesto = Convert.ToDecimal(impuesto);

                    this.objImpresionProforma.Desc_Aplicado = Convert.ToDecimal(descuento);
              
                    this.objImpresionProforma.TotalFactura = Convert.ToDecimal(total);
                  

                    this.objImpresionProforma.subtotal = Convert.ToDecimal(subtotal);

                    this.objImpresionProforma.CajeroNombre = cajero.ToUpper().ToString();

                    this.objImpresionProforma.print();
                }
                if (Apartado == 1)
                {
                    this.objApartado.Articulos.Clear();

                    this.objApartado.AbonoId = Convert.ToInt64(this.txtComprobante.Text);

                    this.objApartado.FechaInicio = Convert.ToDateTime(this.txtFecha.Text);

                    this.objApartado.ClienteNombre = this.txtCliente.Text;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objApartado.Articulos.Add(
                            item.Cells[0].Value.ToString() + ";" +
                            item.Cells[1].Value.ToString() + ";" +
                            item.Cells[2].Value.ToString() + ";" +
                            item.Cells[3].Value.ToString() + ";" +
                            item.Cells[4].Value.ToString() + ";" +
                            item.Cells[5].Value.ToString()
                            );
                    }

                    this.objApartado.MontoAbono = Convert.ToDecimal(this.cobrado);

                    this.objApartado.Impuesto = Convert.ToDecimal(impuesto);

                    this.objApartado.Desc_Aplicado = Convert.ToDecimal(descuento);

                    this.objApartado.TotalFactura = Convert.ToDecimal(total);

                    this.objApartado.Subtotal = Convert.ToDecimal(subtotal);

                    this.objApartado.CajeroNombre = cajero.ToUpper().ToString();

                    this.objApartado.print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar imprimir el detalle: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDatos1_SelectionChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la prefactura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea modificar la prefactura?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Mantenimiento_Proforma form1 = new Mantenimiento_Proforma(this);
                    form1.TopLevel = false;
                    form1.Parent = this;
                    form1.txtComprobante.Text = this.txtComprobante.Text;
                    form1.txtFecha.Text = this.txtFecha.Text;
                    form1.txtHora.Text = this.txtHora.Text;
                    form1.txtCliente.Text=this.txtCliente.Text;
                    form1.txtPorcDesc.Text=this.txtDescuento.Text;
                    form1.txtImpuesto.Text=this.txtImpuesto.Text;
                    form1.txtVendedor.Text=this.txtVendedor.Text;
                    form1.txtTotal.Text = this.txtTotal.Text;


                    form1.txtCodigo.Text = this.dgvDatos1.CurrentRow.Cells[0].Value.ToString();
                    form1.txtArticulo.Text = this.dgvDatos1.CurrentRow.Cells[1].Value.ToString();
                    form1.txtPrecio.Text = this.dgvDatos1.CurrentRow.Cells[2].Value.ToString();
                    form1.txtCantidad.Text = this.dgvDatos1.CurrentRow.Cells[3].Value.ToString();                   
                    form1.txtDescuento.Text = this.dgvDatos1.CurrentRow.Cells[4].Value.ToString();
                    form1.txtImporte.Text = this.dgvDatos1.CurrentRow.Cells[5].Value.ToString();                   
                 //   form1.Prefactura = 1;

                    form1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }

        private void dgvDatos1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btnModificar.PerformClick();
            }
            catch (Exception)
            {

            }
        }
    }
}
