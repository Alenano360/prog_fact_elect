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
    public partial class Login : Form
    {
        
        PuntoVentaBL.Login objLogin = new PuntoVentaBL.Login();

        public static int UserId = 0;

        public static int RolId = 0;

        public string LoginUsuario = string.Empty;

        

        public int Accion = 0;
        public static string LoginUsuarioFinal = string.Empty;
  

        public Login()
        {
            InitializeComponent();
        }

        private void btnCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                this.objLogin.Login_s = this.txtLogin.Text;

                this.objLogin.Contrasena = this.txtContrasena.Text;

                if (this.objLogin.IngresaUsuario() == false)
                {
                    MessageBox.Show("El usuario o contraseña dados son incorrectos o no pertenecen a ninguna cuenta!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.txtLogin.Text = string.Empty;

                    this.txtContrasena.Text = string.Empty;

                    return;
                }

                UserId = this.objLogin.UsuarioId;

                RolId = this.objLogin.RolId;

                LoginUsuario = this.objLogin.Nombre;

                LoginUsuarioFinal = this.objLogin.Nombre;

              

                this.Hide();

                Sel_Mod Modulos = new Sel_Mod(this);

                Modulos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Login_Load(object sender, EventArgs e)
        {
            try
            {
                UserId = 0;

                this.Show();

                this.txtLogin.Text = string.Empty;

                this.txtContrasena.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCompleto.PerformClick();
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtContrasena.Focus();
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLogin_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }
    }
}
