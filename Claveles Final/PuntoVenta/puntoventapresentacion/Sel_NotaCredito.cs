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
    public partial class Sel_NotaCredito : Form
    {
        Facturacion_Mod _owner;

        public string StringFacturaId = string.Empty;

        public Sel_NotaCredito(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Facturacion_Mod_Load();
            
            this._owner.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sel_NotaCredito_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();
            }
            catch (Exception)
            {
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtFacturaId.Text.Length==0)
                {
                    MessageBox.Show("Debe seleccionar una factura a la que enlazar la nota de crédito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.chkImprimeTicket.Checked)
                {
                    _owner.imprime = 1;
                }

                if (this.rbEfectivo.Checked)
                {
                    _owner.PagoEfectivoId = 1;                      
              
                }

                if (this.rbSaldo.Checked)
                {
                    _owner.PagoEfectivoId = 2;
                }

                if (this.rbRegistra.Checked)
                {
                    _owner.PagoEfectivoId = 3;
                }

                _owner.FacturaIdNotaCredito = Convert.ToInt64(this.txtFacturaId.Text);

                _owner.NotaCredito();

                _owner.LimpiaFactura();

                _owner.LimpiaFactura2();

                _owner.NotaCreditoMostrar = 0;

                this.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sel_NotaCredito_Resize(object sender, EventArgs e)
        {
            try
            {
              this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
            }
            catch (Exception)
            {
            }
        }

        private void btnBuscaFactura_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Factura factura = new Sel_Factura(this);
                factura.TopLevel = false;
                factura.Parent = this;
                factura.Show();
            }
            catch (Exception)
            {

            }
        }

        public void CambiaTextoFactura()
        {
            try
            {
                this.txtFacturaId.Text = StringFacturaId;
            }
            catch (Exception)
            {
                
            }
        }

    }
}
