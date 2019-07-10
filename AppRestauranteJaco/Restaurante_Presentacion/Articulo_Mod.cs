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
    public partial class Articulo_Mod : Form
    {
        Principal _owner;
        
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        Restaurante_BL.Articulo objArticulo = new Restaurante_BL.Articulo();

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        public Articulo_Mod(Principal owner)
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
                    MessageBox.Show("Seleccione el artículo a eliminar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el artículo?", "Confirmación", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    this.dgvDatos.Columns[0].Visible = true;

                    this.objArticulo.Id = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);

                    if (this.objArticulo.EliminaArticulo())
                    {
                        this.objArticulo.Nombre = null;

                        this.objArticulo.Orden = "--Seleccione--";

                        this.objArticulo.ObtengoArticulos(this.dgvDatos);

                        MessageBox.Show("Artículo eliminado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.dgvDatos.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void Articulo_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.objArticulo.ObtengoArticulos(this.dgvDatos);

                this.objFamilia.ObtieneFamilia(this.cmbFamilia);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Articulo_Mantenimiento fam = new Articulo_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el detalle del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el artículo a modificar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Articulo_Mantenimiento fam = new Articulo_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                this.dgvDatos.Columns[0].Visible = true;
                fam.ArticuloId = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);
                this.dgvDatos.Columns[0].Visible = false;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Articulo_Mantenimiento fam = new Articulo_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = this;
                this.dgvDatos.Columns[0].Visible = true;
                fam.ArticuloId = Convert.ToInt32(this.dgvDatos.Rows[this.dgvDatos.CurrentCell.RowIndex].Cells[0].Value);
                this.dgvDatos.Columns[0].Visible = false;
                fam.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtieneInfoInferior();

                this.objArticulo.ObtengoArticulos(this.dgvDatos);

                this.objFamilia.ObtieneFamilia(this.cmbFamilia);

                this.cmbFamilia.Text = "--Seleccione--";

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.objArticulo.Orden = this.cmbOrdenar.Text;

                if (this.cmbFamilia.Text!="--Seleccione--")
                {
                    this.objArticulo.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());                    

                    this.objArticulo.ObtengoArticulosXFamilia(this.dgvDatos);
                }
                else
                {
                    this.objArticulo.ObtengoArticulos(this.dgvDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.objArticulo.Orden = this.cmbOrdenar.Text;

                if (this.cmbFamilia.Text != "--Seleccione--")
                {
                    this.objArticulo.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());

                    this.objArticulo.ObtengoArticulosXFamilia(this.dgvDatos);
                }
                else
                {
                    this.objArticulo.ObtengoArticulos(this.dgvDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.objArticulo.Nombre = this.txtBuscar.Text;

                this.objArticulo.Orden = this.cmbOrdenar.Text;

                if (this.cmbFamilia.Text != "--Seleccione--")
                {
                    this.objArticulo.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());

                    this.objArticulo.ObtengoArticulosXFamilia(this.dgvDatos);
                }
                else
                {
                    this.objArticulo.ObtengoArticulos(this.dgvDatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
