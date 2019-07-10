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
    public partial class Usuario_Mantenimiento2 : Form
    {        
        public int Accion = 1;

        public int UsuarioId = 0;

        Usuario_Mantenimiento _owner;

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Usuario objUsuario = new PuntoVentaBL.Usuario();

        public Usuario_Mantenimiento2(Usuario_Mantenimiento owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }


        private void Usuario_Mantenimiento2_Load(object sender, EventArgs e)
        {
            try
            {
                this.objUsuario.ObtieneRoles(this.cmbRoles);
                this.cmbRoles.Enabled = true;

                if (Accion==2)
                {
                    this.objUsuario.Id = Convert.ToInt32(UsuarioId);
                    this.objUsuario.ObtieneUsuarioId();

                    this.txtNombre.Text = this.objUsuario.Nombre;
                    this.txtApellidos.Text = this.objUsuario.Apellido;
                    this.txtLogin.Text = this.objUsuario.Login;
                    this.txtPassword.Text = this.objUsuario.Password;
                    this.cmbRoles.SelectedValue = this.objUsuario.RolId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validacion()
        {
            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el nombre del usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            if (this.txtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el apellido del usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            if (this.txtLogin.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el login del usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            if (this.txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el password del usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validacion())
                {
                    return;
                }

                this.objUsuario.Nombre = this.txtNombre.Text;
                this.objUsuario.Apellido = this.txtApellidos.Text;
                this.objUsuario.Login = this.txtLogin.Text;
                this.objUsuario.Password = this.txtPassword.Text;
                this.objUsuario.Activo = true;
                this.objUsuario.RolId = Convert.ToInt32(this.cmbRoles.SelectedValue.ToString());

                this._owner.LoginAusar = this.txtLogin.Text;



                if (Accion==1)
                {
                    if (this._owner.VerificoLogin() == false)
                    {
                        MessageBox.Show("El login seleccionado ya esta siendo usado. Por favor escriba uno nuevo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el usuario?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.objUsuario.AgregaUsuario(Login.UserId))
                        {
                            MessageBox.Show("Usuario agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Usuario_Mantenimiento_Load(sender, e);

                        this.Close();
                    } 
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el usuario?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {

                        this.objUsuario.Id = this.UsuarioId;

                        if (this.objUsuario.ModificaUsuario(Login.UserId))
                        {
                            MessageBox.Show("Usuario modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Usuario_Mantenimiento_Load(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Usuario_Mantenimiento2_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }
    }
}
