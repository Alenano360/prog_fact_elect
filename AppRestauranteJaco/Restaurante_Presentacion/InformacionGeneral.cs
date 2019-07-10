using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_Presentacion
{
    public partial class InformacionGeneral : Form
    {
        Principal _owner;

        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        public InformacionGeneral(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }

        private void InformacionGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.CargoInfo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargoInfo()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.txtNombre.Text = this.objInformacionGeneral.Nombre;
                this.txtDueno.Text = this.objInformacionGeneral.Dueno;
                this.txtCedula.Text = this.objInformacionGeneral.Cedula;
                this.txtTelefono.Text = this.objInformacionGeneral.Telefono;
                this.txtFax.Text = this.objInformacionGeneral.Fax;
                this.txtPiePagina1.Text = this.objInformacionGeneral.PiePagina1;
                this.txtPiePagina2.Text = this.objInformacionGeneral.PiePagina2;
                this.txtPiePagina3.Text = this.objInformacionGeneral.PiePagina3;
                this.txtPiePagina4.Text = this.objInformacionGeneral.PiePagina4;
                this.txtFinalPagina.Text = this.objInformacionGeneral.FinalPagina;
                if (this.objInformacionGeneral.Impresora != null && this.objInformacionGeneral.Impresora.Length>0)
                {
                    this.cmbImpresoras.Text = this.objInformacionGeneral.Impresora;
                }
                else
                {
                    this.cmbImpresoras.Text = "TM-U220";
                }

                this.txtNumCed.Text = this.objInformacionGeneral._Numero_Cedula;
                this.txtNumSucur.Text = this.objInformacionGeneral._Numero_Sucursal;

                this.txtWeb.Text = this.objInformacionGeneral.Web;
                this.txtIVA.Text = this.objInformacionGeneral.IVA.ToString("F");
                this.txtImpuestoServicio.Text = this.objInformacionGeneral.ImpuestoServicio.ToString("F");
                this.txtTipoCambio.Text = this.objInformacionGeneral.TipoCambio.ToString("F");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + Login.LoginUsuarioFinal.ToString().ToUpper();

                this.tlsNombreRest.Text = "Restaurante: " + this.objInformacionGeneral.Nombre.ToString();

                this.tlsWebHtml.Text = "Web: " + this.objInformacionGeneral.Web.ToString();

                this.tlsFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();

                this.tlsHora.Text = "Hora: " + System.DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = (this.Height - 85) / 5;

                this.tls_Usuario.Width = ((this.Width / 9) * 2) + 15;
                this.tlsNombreRest.Width = ((this.Width / 9) * 3) - 32;
                this.tlsWebHtml.Width = (this.Width / 9) * 2;
                this.tlsFecha.Width = (this.Width / 9);
                this.tlsHora.Width = (this.Width / 9);

                this.panelCompleto.Location = new Point(((this.Width - this.panelCompleto.Width) / 2), 0);
            }
            catch (Exception)
            {
            }
        }

        private void InformacionGeneral_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

            }
        }

        private void LimpiaTextos()
        {
            try
            {
                this.txtNombre.Text = string.Empty;
                this.txtDueno.Text = string.Empty;
                this.txtCedula.Text = string.Empty;
                this.txtTelefono.Text = string.Empty;
                this.txtFax.Text = string.Empty;
                this.txtPiePagina1.Text = string.Empty;
                this.txtPiePagina2.Text = string.Empty;
                this.txtPiePagina3.Text = string.Empty;
                this.txtPiePagina4.Text = string.Empty;
                this.txtFinalPagina.Text = string.Empty;
                this.cmbImpresoras.SelectedIndex = 0;
            }
            catch (Exception)
            {
                
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNombre.Text.Length==0)
                {
                    MessageBox.Show("Por favor digite el nombre del restaurante!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtNombre;
                    return;
                }
                if (this.txtDueno.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite el dueño del restaurante!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtDueno;
                    return;
                }
                if (this.txtCedula.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite la cédula jurídica del restaurante!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtCedula;
                    return;
                }
                if (this.txtTelefono.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite el teléfono del restaurante!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtTelefono;
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtIVA.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor digite unicamente números para el porcentaje de IVA!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtIVA;
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtImpuestoServicio.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor digite unicamente números para el porcentaje de impuesto de servicio!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtImpuestoServicio;
                    return;
                }
                try
                {
                    decimal x = Convert.ToDecimal(this.txtTipoCambio.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor digite unicamente números para el tipo de cambio!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ActiveControl = this.txtTipoCambio;
                    return;
                }
                if (DialogResult.No == MessageBox.Show("¿Está seguro que desea actualizar la información del restaurante?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                this.objInformacionGeneral.Nombre = this.txtNombre.Text;
                this.objInformacionGeneral.Dueno = this.txtDueno.Text;
                this.objInformacionGeneral.Cedula = this.txtCedula.Text;
                this.objInformacionGeneral.Telefono = this.txtTelefono.Text;
                this.objInformacionGeneral.Fax = this.txtFax.Text;
                this.objInformacionGeneral.PiePagina1 = this.txtPiePagina1.Text;
                this.objInformacionGeneral.PiePagina2 = this.txtPiePagina2.Text;
                this.objInformacionGeneral.PiePagina3 = this.txtPiePagina3.Text;
                this.objInformacionGeneral.PiePagina4 = this.txtPiePagina4.Text;
                this.objInformacionGeneral.FinalPagina = this.txtFinalPagina.Text;
                this.objInformacionGeneral.Web = this.txtWeb.Text;
                this.objInformacionGeneral.Impresora = this.cmbImpresoras.Text.ToString();
                this.objInformacionGeneral.IVA = Convert.ToDecimal(this.txtIVA.Text);
                this.objInformacionGeneral.ImpuestoServicio = Convert.ToDecimal(this.txtImpuestoServicio.Text);
                this.objInformacionGeneral.TipoCambio = Convert.ToDecimal(this.txtTipoCambio.Text);


                this.objInformacionGeneral._Numero_Cedula = txtNumCed.Text;
                this.objInformacionGeneral._Numero_Sucursal = txtNumSucur.Text;


                this.objInformacionGeneral.ActualizaInformacionRestaurantes();

                MessageBox.Show("La información ha sido actualizada con éxito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfguracionFacturaElectronica newWindow = new ConfguracionFacturaElectronica();
            newWindow.Show();
        }
    }
}
