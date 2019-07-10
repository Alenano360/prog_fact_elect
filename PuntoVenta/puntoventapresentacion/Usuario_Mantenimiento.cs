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
    public partial class Usuario_Mantenimiento : Form
    {        
        public int Accion = 1;

        public int UsuarioId = 0;

        public string LoginAusar = string.Empty;

        Sel_Mod _owner;

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Usuario objUsuario = new PuntoVentaBL.Usuario();

        public Usuario_Mantenimiento(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        public bool VerificoLogin()
        {
            try
            {
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    if (item.Cells[4].Value.ToString()==LoginAusar)
                    {
                        return false;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar verfificar el login: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }


        public void Usuario_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.objUsuario.ObtieneUsuarios(this.dgvDatos);
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

        private void Usuario_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count>0)
                {
                    Usuario_Mantenimiento2 usuario = new Usuario_Mantenimiento2(this);
                    usuario.TopLevel = false;
                    usuario.Parent = this;
                    usuario.Accion = 2;
                    usuario.UsuarioId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    usuario.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario_Mantenimiento2 usuario = new Usuario_Mantenimiento2(this);
                usuario.TopLevel = false;
                usuario.Parent = this;
                usuario.Accion = 1;                
                usuario.Show();

            }            
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el usuario?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            this.objUsuario.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                            this.objUsuario.EliminaUsuario(Login.UserId);

                            this.Usuario_Mantenimiento_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el usuario: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
