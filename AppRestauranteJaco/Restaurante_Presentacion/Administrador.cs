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
    public partial class Administrador : Form
    {
        Principal _owner;

        Login _login;

        Restaurante_BL.CAdministrador objAdministrador = new Restaurante_BL.CAdministrador();
        Restaurante_BL.Metodos eliminar = new Restaurante_BL.Metodos();

        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        public Administrador(Principal owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _owner.Principal_Load(sender, e);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objAdministrador.ObtieneTiposUsuario(this.cmbUsuarios);

                this.objAdministrador.ObtieneTiposUsuario(this.cmbRol);

                this.objAdministrador.UsuarioId = 0;

                this.ObtieneInfoInferior();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {                
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + Restaurante_Presentacion.Login.LoginUsuarioFinal.ToString().ToUpper();

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

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.objAdministrador.RolId = Convert.ToInt32(this.cmbUsuarios.SelectedValue.ToString());

                this.dgvUsuariosXtipo.Columns[0].Visible = true;

                this.objAdministrador.ObtieneUsuariosXTipo(this.dgvUsuariosXtipo);

                this.dgvUsuariosXtipo.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información de los tipos de usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuariosXtipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvUsuariosXtipo.Columns[0].Visible = true;

                this.objAdministrador.UsuarioId = Convert.ToInt32(this.dgvUsuariosXtipo.Rows[e.RowIndex].Cells[0].Value.ToString());
               // MessageBox.Show("El usuario es " + this.objAdministrador.UsuarioId);

                this.dgvUsuariosXtipo.Columns[0].Visible = false;

                if (e.ColumnIndex == this.dgvUsuariosXtipo.Columns["Eliminar"].Index)
                {
                    if ((MessageBox.Show("¿Está seguro que desea eliminar el registro del usuario?", "Eliminación de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (Restaurante_Presentacion.Login.LoginUsuarioFinal == this.dgvUsuariosXtipo.Rows[e.RowIndex].Cells[1].Value.ToString())
                        {
                            MessageBox.Show("No puede eliminar su propio usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

                      //  this.objAdministrador.EliminaUsuario();
                        //vamos a eliminar usuario
                        String query = "";
                        String mensaje = "";
                        query = "sp_eliminar_usuario " + this.objAdministrador.UsuarioId;
                        mensaje = eliminar.eliminar_usuario(query);
                        MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Eventos de Administrador_Load y NuevoUsuario(LimpiaControles)
                        this.cmbUsuarios.SelectedIndex = 0;

                        this.cmbRol.SelectedIndex = 0;

                        this.objAdministrador.UsuarioId = 0;

                        this.objAdministrador.UsuarioId = 0;

                        this.txtNombre.Text = string.Empty;

                        this.txtApellidos.Text = string.Empty;

                        this.txtLogin.Text = string.Empty;

                        this.txtPassword.Text = string.Empty;

                        this.chkActivo.Checked = false;

                        this.chkNoActivo.Checked = false;

                        this.cmbRol.SelectedIndex = 0;

                        this.cmbRol.Text = "-- Seleccione --";
                        this.Hide();

                        return;
                    } 
                }

                this.objAdministrador.ObtieneUsuario();

                this.txtLogin.Text = this.objAdministrador.Login;

                this.txtPassword.Text = this.objAdministrador.Contrasena;

                this.txtNombre.Text = this.objAdministrador.Nombre;

                this.txtApellidos.Text = this.objAdministrador.Apellidos;

                if (this.objAdministrador.Activo==true)
                {
                    this.chkActivo.Checked = true;
                }
                else
                {
                    this.chkNoActivo.Checked = true;
                }

                this.cmbRol.SelectedIndex = (this.objAdministrador.RolId-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar hacer el mantenimiento del usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivo.Checked)
            {
                this.chkNoActivo.Checked = false;
            }            
        }

        private void chkNoActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoActivo.Checked)
            {
                this.chkActivo.Checked = false;
            }        
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.objAdministrador.UsuarioId = 0;

                this.txtLogin.Text = string.Empty;

                this.txtPassword.Text = string.Empty;

                this.txtNombre.Text = string.Empty;

                this.txtApellidos.Text = string.Empty;

                this.chkActivo.Checked = false;

                this.chkNoActivo.Checked = false;

                this.cmbRol.SelectedIndex = 0;

                this.cmbRol.Text = "-- Seleccione --";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear el nuevo usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtLogin.Text.Length==0||this.txtPassword.Text.Length==0||(this.chkActivo.Checked==false &&this.chkNoActivo.Checked==false)||this.cmbRol.Text=="-- Seleccione --")
                {
                    MessageBox.Show("Por favor digite los datos requeridos!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                this.objAdministrador.Login = this.txtLogin.Text;

                this.objAdministrador.Contrasena = this.txtPassword.Text;

                this.objAdministrador.Nombre = this.txtNombre.Text;

                this.objAdministrador.Apellidos = this.txtApellidos.Text;

                if (this.chkActivo.Checked)
                {
                    this.objAdministrador.Activo = true;
                }

                if (this.chkNoActivo.Checked)
                {
                    this.objAdministrador.Activo = false;
                }

                this.objAdministrador.RolId = Convert.ToInt32(this.cmbRol.SelectedValue.ToString());

                if (this.objAdministrador.UsuarioId!=0)//modificar
                {
                    if ((MessageBox.Show("¿Está seguro que desea modificar el registro del usuario?", "Modificación de usuario",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes))
                    {
                        this.objAdministrador.Accion = 0;                        
                    } 
                }
                else
                {
                    if (this.cmbRol.Text == "-- Seleccione --")
                    {
                        MessageBox.Show("Seleccione el rol del nuevo usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        return;
                    }

                    if (this.objAdministrador.VerificoLogin())
                    {
                        MessageBox.Show("El login seleccionado no esta disponible!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if ((MessageBox.Show("¿Está seguro que desea agregar el registro del usuario?", "Modificación de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        this.objAdministrador.Accion = 1;      
                    }                                      
                }

                this.objAdministrador.MantenimientoUsuario();

                this.Administrador_Load(sender, e);

                this.btnNuevoUsuario_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear el nuevo usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Administrador_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
