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
    public partial class Proforma_Anexo : Form
    {
        Facturacion_Mod _owner1;

        PuntoVentaBL.Proforma objProforma = new PuntoVentaBL.Proforma();

        public Proforma_Anexo(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner1 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner1.Show();
        }

        private void Proforma_Anexo_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear el anexo de la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption,string option1,string option2)
            {
                string result = string.Empty;
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.ControlBox = false;
                prompt.Width = 350;
                prompt.Height = 160;
                prompt.Text = caption;
                prompt.FormBorderStyle = FormBorderStyle.FixedSingle; 
                Label textLabel = new Label() { Top = 20, Text = text, Width=350 ,TextAlign=ContentAlignment.MiddleCenter};
                Button op1 = new Button() { Text = option1, Left = 50, Width = 100, Top = 70 };
                Button op2 = new Button() { Text = option2, Left = 200, Width = 100, Top = 70 };
                op1.Click += (sender, e) => { result=op1.Text; prompt.Close(); };
                op2.Click += (sender, e) => { result = op2.Text; prompt.Close(); };
                prompt.Controls.Add(op1);
                prompt.Controls.Add(op2);
                prompt.Controls.Add(textLabel);
                prompt.ShowDialog();
                return (string)result;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _owner1.Proforma();

                this.objProforma.Id = _owner1.ProfId;
                this.objProforma.VigenciaOferta = this.txtVigencia.Text;
                this.objProforma.AtencionA = this.txtAtencion.Text;
                this.objProforma.CondicionPago = this.txtCondiciones.Text;
                this.objProforma.TiempoEntrega = this.txtEntrega.Text;
                this.objProforma.Comentarios = this.txtComentarios.Text;

                this.objProforma.InsertaAnexo();

                if (Prompt.ShowDialog("Por favor seleccione el método de impresión","Selección","Ticket","Gráfico")=="Ticket")
                {
                    //imprime ticket
                    _owner1.ConstruyeTicket();
                }
                else
                {
                    _owner1.ImprimeGraficoProforma();
                    //imprime grafico
                }


                _owner1.LimpiaFactura();

                _owner1.ProforomaMostrar = 0;

                _owner1.LimpiaFactura2();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Proforma_Anexo_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }
    }
}
