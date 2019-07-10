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
    public partial class Familia_Mod : Form
    {
        Principal _owner;
        
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        public Familia_Mod(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la familia a eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la familia?", "Confirmación", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    this.dgvDatos.Columns[0].Visible = true;

                    this.objFamilia.Id = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);

                    if (this.objFamilia.EliminaFamilia())
                    {
                        this.objFamilia.ObtengoFamilia(this.dgvDatos);
                     
                        MessageBox.Show("Familia eliminada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.dgvDatos.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void Familia_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.objFamilia.ObtengoFamilia(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Familia_Mantenimiento fam = new Familia_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el detalle de la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la familia a modificar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Familia_Mantenimiento fam = new Familia_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                this.dgvDatos.Columns[0].Visible = true;
                fam.FamiliaId = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);
                this.dgvDatos.Columns[0].Visible = false;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Familia_Mantenimiento fam = new Familia_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                this.dgvDatos.Columns[0].Visible = true;
                fam.FamiliaId = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);
                this.dgvDatos.Columns[0].Visible = false;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Familia_Mod_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

            }
        }
    }
}
