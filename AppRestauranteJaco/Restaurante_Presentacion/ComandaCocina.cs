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
    public partial class ComandaCocina : Form
    {
        Login _owner;

        Restaurante_BL.CComandaCocina objComandaCocina = new Restaurante_BL.CComandaCocina();
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        public ComandaCocina(Login owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
        public int accion = 0;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (accion == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro que desea salir del sistema?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _owner.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }   
        }

        private void ComandaCocina_Load(object sender, EventArgs e)
        {
            try
            {
                this.ObtieneInfoInferior();

                this.ObtienePorEntregar();

                this.ResizeLoad();

                this.timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al cargar la información de la comanda de la cocina: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + _owner.LoginUsuario.ToString().ToUpper();

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

        private void ObtienePorEntregar()
        {
            try
            {
                this.objComandaCocina.ObtieneComandaCocina();

                int locx = 30;
                int locy = 75;

                foreach (string item in this.objComandaCocina.ListaComandaCocina)
                {
                    string[] temp = item.Split('|');

                    Label lbl = new Label();
                    {
                        lbl.Name = temp[0].ToString();//id del temporalconsumo
                        lbl.Text = temp[1].ToString();
                        lbl.Width = 500;
                        lbl.Font = new Font(lbl.Font.FontFamily, 14, lbl.Font.Style);
                        lbl.TextAlign = ContentAlignment.MiddleLeft;
                        lbl.Location = new Point(locx, locy);
                    }
                    this.panelCocina.Controls.Add(lbl);

                    locx += 495;

                    Label lblCantidad = new Label();
                    {
                        lblCantidad.Name = "lblCantidad" + temp[0].ToString();
                        lblCantidad.Text = temp[2].ToString();
                        lblCantidad.Width = 100;
                        lblCantidad.Font = new Font(lbl.Font.FontFamily, 18, lbl.Font.Style | FontStyle.Bold);
                        lblCantidad.TextAlign = ContentAlignment.MiddleLeft;
                        lblCantidad.Location = new Point(locx, locy + 5);
                    }
                    this.panelCocina.Controls.Add(lblCantidad);

                    locx += 160;

                    Label lblMesa = new Label();
                    {
                        lblMesa.Name = "lblMesa" + temp[0].ToString();
                        lblMesa.Text = temp[3].ToString();
                        lblMesa.Width = 50;//625
                        lblMesa.Font = new Font(lbl.Font.FontFamily, 18, lbl.Font.Style | FontStyle.Bold);
                        lblMesa.TextAlign = ContentAlignment.MiddleLeft;
                        lblMesa.Location = new Point(locx, locy + 5);
                    }
                    this.panelCocina.Controls.Add(lblMesa);

                    locx += 92;

                    Button btn = new Button();
                    {
                        btn.Name = "btnEntregado" + temp[0].ToString();
                        btn.Text = "Entregado";
                        btn.Width = 150;//625
                        btn.Height = 40;
                        btn.Font = new Font(lbl.Font.FontFamily, 18, lbl.Font.Style | FontStyle.Bold);
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        btn.Location = new Point(locx, locy);
                        btn.Click += new EventHandler(btnEntregaOrden);
                    }
                    this.panelCocina.Controls.Add(btn);

                    locx = 30;
                    locy += 50;
                }
                //this.gbEntregar.Height = locy + 25;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al cargar la comanda de la cocina: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnEntregaOrden(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                string id = btn.Name.Substring(btn.Name.ToString().Length - 3, 3).ToString();

                this.objComandaCocina.TemporalConsumoId = Convert.ToInt32(id);

                this.objComandaCocina.DesactivaOrden();

                this.panelCocina.Controls.Clear();

                //int locx = 30;
                //int locy = 40;

                //Label lbl1 = new Label();
                //{
                //    lbl1.Name = "label1";
                //    lbl1.Text = "PRODUCTO";
                //    lbl1.Width = 152;
                //    lbl1.Font = new Font(lbl1.Font.FontFamily, 16, lbl1.Font.Style);
                //    lbl1.TextAlign = ContentAlignment.TopLeft;
                //    lbl1.Location = new Point(locx, locy);
                //}
                //this.panelCocina.Controls.Add(lbl1);

                //locx += 300;

                //Label lbl2 = new Label();
                //{
                //    lbl2.Name = "label2";
                //    lbl2.Text = "CANTIDAD";
                //    lbl2.Width = 152;
                //    lbl2.Font = new Font(lbl2.Font.FontFamily, 16, lbl2.Font.Style);
                //    lbl2.TextAlign = ContentAlignment.TopLeft;
                //    lbl2.Location = new Point(330, locy);
                //}
                //this.panelCocina.Controls.Add(lbl2);

                //locx += 275;

                //Label lbl3 = new Label();
                //{
                //    lbl3.Name = "label3";
                //    lbl3.Text = "MESA";
                //    lbl3.Width = 152;
                //    lbl3.Font = new Font(lbl3.Font.FontFamily, 16, lbl3.Font.Style);
                //    lbl3.TextAlign = ContentAlignment.TopLeft;
                //    lbl3.Location = new Point(625, locy);
                //}
                //this.panelCocina.Controls.Add(lbl3);

                //locx += 175;

                //Label lbl4 = new Label();
                //{
                //    lbl4.Name = "lbl4";
                //    lbl4.Text = "ENTREGADO";
                //    lbl4.Width = 152;
                //    lbl4.Font = new Font(lbl4.Font.FontFamily, 16, lbl4.Font.Style);
                //    lbl4.TextAlign = ContentAlignment.TopLeft;
                //    lbl4.Location = new Point(800, locy);
                //}
                //this.panelCocina.Controls.Add(lbl4);

                this.ObtienePorEntregar();
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al aumentar la orden: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _owner.Login_Load(sender, e);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComandaCocina_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {                
                this.ObtienePorEntregar();
            }
            catch (Exception)
            {

            }
        }

        private void cerrarSesiónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _owner.Login_Load(sender, e);

                    accion = 1;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
