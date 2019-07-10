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
    public partial class Informacion_General : Form
    {
        Sel_Mod _owner;

        public Informacion_General(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void InformacionGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();

                this.CargaTs();

                this.CargoInfo();

                this.BringToFront();
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
                this.objInformacionGeneral.ObtengoInformacion();

                this.txtNombre.Text = this.objInformacionGeneral.Nombre;
                this.txtDueno.Text = this.objInformacionGeneral.Dueno;
                this.txtCedula.Text = this.objInformacionGeneral.Cedula;
                this.txtTelefono.Text = this.objInformacionGeneral.Telefono;
                this.txtFax.Text = this.objInformacionGeneral.Fax;
                this.txtEncabezado1.Text = this.objInformacionGeneral.Encabezado1;
                this.txtEncabezado2.Text = this.objInformacionGeneral.Encabezado2;
                this.txtEncabezado3.Text = this.objInformacionGeneral.Encabezado3;
                this.txtEncabezado4.Text = this.objInformacionGeneral.Encabezado4;
                this.txtPiePagina1.Text = this.objInformacionGeneral.PiePagina1;
                this.txtPiePagina2.Text = this.objInformacionGeneral.PiePagina2;
                this.txtPiePagina3.Text = this.objInformacionGeneral.PiePagina3;
                this.txtPiePagina4.Text = this.objInformacionGeneral.PiePagina4;
                this.txtPiePagina5.Text = this.objInformacionGeneral.PiePagina5;
                this.txtPiePagina6.Text = this.objInformacionGeneral.PiePagina6;
                this.txtPiePagina7.Text = this.objInformacionGeneral.PiePagina7;
                this.txtPiePagina8.Text = this.objInformacionGeneral.PiePagina8;

                this.txtNumCed.Text = this.objInformacionGeneral._Numero_Cedula;
                this.txtNumSucur.Text = this.objInformacionGeneral._Numero_Sucursal;

                if (this.objInformacionGeneral.Impresora != null && this.objInformacionGeneral.Impresora.Length > 0)
                {
                    this.cmbImpresoras.Text = this.objInformacionGeneral.Impresora;
                }
                else
                {
                    this.cmbImpresoras.Text = "TM-U220";
                }
                this.txtIVA.Text = this.objInformacionGeneral.IVA.ToString("F");
                this.txtCambio.Text = this.objInformacionGeneral.TipoCambio.ToString("F");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        PuntoVentaBL.InformacionGeneral objInformacionGeneral = new PuntoVentaBL.InformacionGeneral();

        private void CargaTs()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información general: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = (this.Height - 85) / 5;


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
                this.txtEncabezado1.Text = string.Empty;
                this.txtEncabezado2.Text = string.Empty;
                this.txtEncabezado3.Text = string.Empty;
                this.txtEncabezado4.Text = string.Empty;
                this.txtPiePagina1.Text = string.Empty;
                this.txtPiePagina2.Text = string.Empty;
                this.txtPiePagina3.Text = string.Empty;
                this.txtPiePagina4.Text = string.Empty;
                this.txtPiePagina5.Text = string.Empty;
                this.txtPiePagina6.Text = string.Empty;
                this.txtPiePagina7.Text = string.Empty;
                this.txtPiePagina8.Text = string.Empty;
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

                if (DialogResult.No == MessageBox.Show("¿Está seguro que desea actualizar la información del restaurante?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                this.objInformacionGeneral.Nombre = this.txtNombre.Text;
                this.objInformacionGeneral.Dueno = this.txtDueno.Text;
                this.objInformacionGeneral.Cedula = this.txtCedula.Text;
                this.objInformacionGeneral.Telefono = this.txtTelefono.Text;
                this.objInformacionGeneral.Fax = this.txtFax.Text;
                this.objInformacionGeneral.Encabezado1 = this.txtEncabezado1.Text;
                this.objInformacionGeneral.Encabezado2 = this.txtEncabezado2.Text;
                this.objInformacionGeneral.Encabezado3 = this.txtEncabezado3.Text;
                this.objInformacionGeneral.Encabezado4 = this.txtEncabezado4.Text;
                this.objInformacionGeneral.PiePagina1 = this.txtPiePagina1.Text;
                this.objInformacionGeneral.PiePagina2 = this.txtPiePagina2.Text;
                this.objInformacionGeneral.PiePagina3 = this.txtPiePagina3.Text;
                this.objInformacionGeneral.PiePagina4 = this.txtPiePagina4.Text;
                this.objInformacionGeneral.PiePagina5 = this.txtPiePagina5.Text;
                this.objInformacionGeneral.PiePagina6 = this.txtPiePagina6.Text;
                this.objInformacionGeneral.PiePagina7 = this.txtPiePagina7.Text;
                this.objInformacionGeneral.PiePagina8 = this.txtPiePagina8.Text;
                
                this.objInformacionGeneral.Impresora = this.cmbImpresoras.Text.ToString();
                this.objInformacionGeneral.IVA = Convert.ToDecimal(this.txtIVA.Text);
                this.objInformacionGeneral.TipoCambio = Convert.ToDecimal(this.txtCambio.Text);

                this.objInformacionGeneral._Numero_Cedula = txtNumCed.Text;
                this.objInformacionGeneral._Numero_Sucursal = txtNumSucur.Text;

                this.objInformacionGeneral.ActualizaInformacion();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
