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
    public partial class CajaDiaria_Arqueo : Form
    {
        CajaDiaria_Mod _owner;

        PuntoVentaBL.ImprimeArqueo objArqueo = new PuntoVentaBL.ImprimeArqueo();

        public CajaDiaria_Arqueo(CajaDiaria_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void CajaDiaria_Arqueo_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.CargaGridColones();
                
                this.CargaGridDolares();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el arqueo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargaGridColones()
        {
            try
            {
                this.dgvColones.Rows.Add("Billete de 50,000", "50,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Billete de 20,000", "20,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Billete de 10,000", "10,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Billete de 5,000", "5,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Billete de 2,000", "2,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Billete de 1,000", "1,000.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 500", "500.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 100", "100.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 50", "50.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 25", "25.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 10", "10.00", "0", "0.00");
                this.dgvColones.Rows.Add("Moneda de 5", "5.00", "0", "0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los tipos de denominaciones de colones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargaGridDolares()
        {
            try
            {
                this.dgvDolares.Rows.Add("Billete de 100", "100.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Billete de 50", "50.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Billete de 20", "20.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Billete de 10", "10.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Billete de 5", "5.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Billete de 1", "1.00", "0", "0.00");
                this.dgvDolares.Rows.Add("Moneda de 0.50", "0.50", "0", "0.00");
                this.dgvDolares.Rows.Add("Moneda de 0.25", "0.25", "0", "0.00");
                this.dgvDolares.Rows.Add("Moneda de 0.10", "0.10", "0", "0.00");
                this.dgvDolares.Rows.Add("Moneda de 0.01", "0.01", "0", "0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los tipos de denominaciones de colones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvColones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal totalColones = 0;
                foreach (DataGridViewRow item in this.dgvColones.Rows)
                {
                    item.Cells[3].Value = (Convert.ToDecimal(item.Cells[1].Value) * Convert.ToDecimal(item.Cells[2].Value)).ToString("##,#0.#0");
                    totalColones += Convert.ToDecimal(item.Cells[3].Value);
                }

                this.txtTotalColones.Text = totalColones.ToString("##,#0.#0");
            }
            catch (Exception)
            {

            }
        }

        private void dgvDolares_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal totalDolares = 0;
                foreach (DataGridViewRow item in this.dgvDolares.Rows)
                {
                    item.Cells[3].Value = (Convert.ToDecimal(item.Cells[1].Value) * Convert.ToDecimal(item.Cells[2].Value)).ToString("##,#0.#0");
                    totalDolares += Convert.ToDecimal(item.Cells[3].Value);
                }

                this.txtTotalDolares.Text = totalDolares.ToString("##,#0.#0");
            }
            catch (Exception)
            {

            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in this.dgvColones.Rows)
                {
                    if (Convert.ToDecimal(item.Cells[3].Value)>0)
                    {
                        this.objArqueo.Colones.Add(item.Cells[0].Value + ";" + item.Cells[2].Value + ";" + item.Cells[3].Value);//nombre cantidad total
                    }
                }

                foreach (DataGridViewRow item in this.dgvDolares.Rows)
                {
                    if (Convert.ToDecimal(item.Cells[3].Value) > 0)
                    {
                        this.objArqueo.Dolares.Add(item.Cells[0].Value + ";" + item.Cells[2].Value + ";" + item.Cells[3].Value);//nombre cantidad total
                    }
                }

                this.objArqueo.TotalColones = this.txtTotalColones.Text;

                this.objArqueo.TotalDolares = this.txtTotalDolares.Text;

                this.objArqueo.TotalTarjeta = this.txtTotalTarjetas.Text;

                this.objArqueo.Usuario = Login.LoginUsuarioFinal;

                this.objArqueo.print();

                this.dgvColones.Rows.Clear();

                this.dgvDolares.Rows.Clear();

                this.CargaGridColones();

                this.CargaGridDolares();

                this.txtTotalColones.Text = "0.00";

                this.txtTotalDolares.Text = "0.00";

                this.txtTotalTarjetas.Text = "0.00";
            }
            catch (Exception)
            {
            }
        }

        private void txtTotalColones_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalTarjetas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalDolares_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalTarjetas_Leave(object sender, EventArgs e)
        {
            try
            {
                string x = Convert.ToDecimal(this.txtTotalTarjetas.Text).ToString("##,#0.#0");

                this.txtTotalTarjetas.Text = x;
            }
            catch (Exception)
            {
            }
        }

        private void CajaDiaria_Arqueo_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }
    }
}
