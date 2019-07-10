using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoVentaBL;
using PuntoVentaDAL;

namespace PuntoVentaPresentacion
{
    public partial class BitacoraInventario : Form
    {
        public BitacoraInventario()
        {
            InitializeComponent();
        }
        PuntoVentaBL.Consultas Consultas = new PuntoVentaBL.Consultas();

        private void BitacoraInventario_Load(object sender, EventArgs e)
        {
            CargarComponente();

        }

        public void CargarComponente()
        {
            Consultas.ObtieneInventarioMovimientos(this.C);
            Consultas.CargarMovimientos(cmbOrdenar);
            Consultas.CargarUsuarios(cmbUser);


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filtar por movimientos
            try
            {
                String filtro = cmbOrdenar.Text;
                Consultas.CargarFiltro(this.C, cmbOrdenar.Text);
                if (filtro != "Modifico productos")
                {

                   C.Columns[3].Visible = false;
                }
                else
                {
                    C.Columns[3].Visible = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filtar por movimientos y usuarios
            try
            {
                String filtro = cmbOrdenar.Text;
                Consultas.CargarFiltroUsuario(this.C, cmbOrdenar.Text, cmbUser.Text);
                if (filtro != "Modifico productos")
                {

                    C.Columns[3].Visible = false;
                }
                else
                {
                    C.Columns[3].Visible = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtfecha_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtfecha_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    if (this.txtfecha.Text.Length > 0)
                    {
                        String filtro = cmbOrdenar.Text;
                        Consultas.CargarFiltroUsuarioFecha(this.C, cmbOrdenar.Text, cmbUser.Text,txtfecha.Text);
                        if (filtro != "Modifico productos")
                        {

                            C.Columns[3].Visible = false;
                        }
                        else
                        {
                            C.Columns[3].Visible = true;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
