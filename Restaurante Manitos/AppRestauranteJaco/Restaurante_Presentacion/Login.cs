using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Presentacion
{
    public partial class Login : Form
    {
        Restaurante_BL.Login objLogin = new Restaurante_BL.Login();

        public static int UserId = 0;

        public static int RolId = 0;

        public string LoginUsuario = string.Empty;

        public static string LoginUsuarioFinal = string.Empty;

        public static string RolDescripcion = string.Empty;

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

                LoginUsuario = this.objLogin.Login_s;

                LoginUsuarioFinal = this.objLogin.Login_s;

                RolDescripcion = this.objLogin.RolDescripcion.ToString();

                RolId = this.objLogin.RolId;


                this.Hide();

                switch (this.objLogin.RolId)
                {
                    case 1:
                        {
                            //Administrador objAdmin = new Administrador(this);
                            //objAdmin.Show();
                            //break;
                            Principal objPrincipal = new Principal(this);
                            objPrincipal.Show();
                            break;
                        }

                    case 2:
                        {
                            Principal objPrincipal = new Principal(this);
                            objPrincipal.Show();
                            break;
                        }
                    case 3:
                        {
                            ComandaBar objComandaBar = new ComandaBar(this);
                            objComandaBar.Show();
                            break;
                        }
                    case 4:
                        {
                            ComandaCocina objComandaCocina = new ComandaCocina(this);
                            objComandaCocina.Show();
                            break;
                        }
                    default:
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message,"Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        void Login_Load_1(object sender, EventArgs e)
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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    this.btnCompleto.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.btnCompleto.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }
    }
}
