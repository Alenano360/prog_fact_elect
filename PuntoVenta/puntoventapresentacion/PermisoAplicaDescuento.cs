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
    public partial class PermisoAplicaDescuento : Form
    {
        PuntoVentaBL.Login objLogin = new PuntoVentaBL.Login();

        Facturacion_Mod _owner;

        public PermisoAplicaDescuento(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();     
        }
        private void btnCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                this.objLogin.Login_s = this.txtLogin.Text;

                this.objLogin.Contrasena = this.txtContrasena.Text;

                if (this.objLogin.IngresaUsuarioPermiso() == false)
                {
                    MessageBox.Show("El usuario o contraseña dados son incorrectos o no pertenecen a ninguna cuenta!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.txtLogin.Text = string.Empty;

                    this.txtContrasena.Text = string.Empty;

                    return;
                }

                _owner.AbreCajaDescuento();

                _owner.permiso = 1;

                this.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PermisoAplicaDescuento_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==(Keys.Enter))
            {
                btnCompleto_Click(sender, e);
            }
        }
    }
}
