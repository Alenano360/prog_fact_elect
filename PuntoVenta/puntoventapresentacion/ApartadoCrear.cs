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
    public partial class ApartadoCrear : Form
    {
        Facturacion_Mod _owner;

        public decimal Total = 0;

        public int DescuentoCajaDiaria = 0;

        public decimal MontoEfectivo = 0;

        public decimal MontoTarjeta = 0;

        public decimal MontoNotaCredito = 0;

        public List<string> ListaNotasCredito = new List<string>();

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        public ApartadoCrear(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void ApartadoCrear_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.txtTotal.Text = this.Total.ToString("##,#0.#0");

                this.ActiveControl = this.txtAbono;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }

                if (Convert.ToDecimal(this.txtAbono.Text)<1)
                {
                    MessageBox.Show("El monto digitado en abono es incorrecto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDecimal(this.txtAbono.Text) < Convert.ToDecimal(this.txtTotal.Text))//si el abono es menor al total se guarda l apartado
                {
                    Facturacion_Pago form = new Facturacion_Pago(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Total = Convert.ToDecimal(this.txtAbono.Text);
                    form.Apartado = 1;
                    form.Show();
                }
                else//
                {
                    if (DialogResult.Yes==MessageBox.Show("¿Desea facturar en vez de realizar el apartado?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        this._owner.CambiaAFacturacion();
                        this.Close();
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiaFactura()
        {
            this._owner.LimpiaFactura();
            this._owner.LimpiaFactura2();
        }

        public void RealizoApartado()
        {
            try
            {
                this._owner.MontoApartado = Convert.ToDecimal(this.txtAbono.Text);
                this._owner.DiasApartado = Convert.ToInt32(this.txtDias.Text);

                //if (this.DescuentoCajaDiaria == 0)
                //{
                //    this._owner.DescuentoCajaDiaria = 0;
                //}

                //if (this.DescuentoCajaDiaria==1)
                //{
                //    this._owner.DescuentoCajaDiaria = 1;
                //}

                //if (this.DescuentoCajaDiaria == 2)
                //{
                //    this._owner.DescuentoCajaDiaria = 2;
                //}

                

                this._owner.GeneraApartado();


                MessageBox.Show("Apartado realizado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApartadoCrear_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            this.txtTotal.Text = Convert.ToDecimal(this.txtTotal.Text).ToString("##,#0.#0");
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Digite números para el total", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtAbono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal x = Convert.ToDecimal(this.txtAbono.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Digite números para el abono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAbono_Leave(object sender, EventArgs e)
        {
            this.txtAbono.Text = Convert.ToDecimal(this.txtAbono.Text).ToString("##,#0.#0");

            if (Convert.ToDecimal(this.txtAbono.Text)>Convert.ToDecimal(this.txtTotal.Text))
            {
                this.txtAbono.Text = this.txtTotal.Text;
            }
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(this.txtDias.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Digite números para los dias", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDias_Leave(object sender, EventArgs e)
        {

        }
    }
}
