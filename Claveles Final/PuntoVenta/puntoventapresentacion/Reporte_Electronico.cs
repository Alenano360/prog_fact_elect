using Newtonsoft.Json.Linq;
using PuntoVentaBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PuntoVentaPresentacion
{
    public partial class Reporte_Electronico : Form
    {
        public Datos_Electronicos  get_Reportes = new Datos_Electronicos();
        public Sel_Mod _owner;
        public DataGridView origin = new DataGridView();
        public Reporte_Electronico()
        {
            InitializeComponent();
        }

        private void Reporte_Electronico_Load(object sender, EventArgs e)
        {
            fill_data_by_date();
        }

        private void CalcularMontoTotal()
        {
            int total = 0;
            foreach (DataGridViewRow rowView in dataGridView1.Rows)
            {
                total += Convert.ToInt32(rowView.Cells["montoFacturaDataGridViewTextBoxColumn"].Value);

            }

            txt_monto_total.Text = total.ToString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fill_data_by_date();
        }


        private void switched(bool env, bool date, bool cancel)
        {
            if (env)
            {
                lb_desde.Visible = false;
                lb_hasta.Visible = false;
                cbDateDesde.Visible = false;
                cbDateHasta.Visible = false;
                btnEnviar.Visible = true;
                fill_data_by_notsend();
            }

            if (date)
            {
                lb_desde.Visible = true;
                lb_hasta.Visible = true;
                cbDateDesde.Visible = true;
                cbDateHasta.Visible = true;
                btnEnviar.Visible = false;
                fill_data_by_date();
            }
            
            if(cancel)
            { 
                lb_desde.Visible = true;
                lb_hasta.Visible = true;
                cbDateDesde.Visible = true;
                cbDateHasta.Visible = true;
                btnEnviar.Visible = false;
                fill_data_by_cancel();
            }
        }

        private void chk_controller(bool env, bool date, bool cancel)
        {
            if (env)
            {
                chkEnv.Checked = true;
                chkDate.Checked = false;
                chk_cancelar.Checked = false;
                switched(true, false, false);
            }

            if (date)
            {
                chkDate.Checked = true;
                chkEnv.Checked = false;
                chk_cancelar.Checked = false;
                switched(false, true, false);
            }

            if (cancel)
            {
                chk_cancelar.Checked = true;
                chkDate.Checked = false;
                chkEnv.Checked = false;
                switched(false, false, true);
            }
        }
        

        private void chkEnv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnv.Checked)
            {
                chk_controller(true, false, false);
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                chk_controller(false, true, false);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cancelar.Checked)
            {
                chk_controller(false, false, true);
            }
        }

        
        public void fill_data_by_date()
        {
            string desde = cbDateDesde.Value.ToString("MM-dd-yyyy");
            DateTime Date_desde = DateTime.ParseExact(desde, "MM-dd-yyyy", null);

            string hasta = cbDateHasta.Value.ToString("MM-dd-yyyy");
            DateTime Date_hasta = DateTime.ParseExact(hasta, "MM-dd-yyyy", null);
            
            if (chk_t_fact.Checked)
            {
                dataGridView1.DataSource = get_Reportes.Get_FacturasXFecha(Date_desde, Date_hasta);
                dataGridView1.Columns["id_FacturaElectronica"].Visible = false;
            }

            else
            {
                dataGridView1.DataSource = get_Reportes.Get_TiquetesXFecha(Date_desde, Date_hasta);
                dataGridView1.Columns["id_TiqueteElectronico"].Visible = false;
            }
            
            CalcularMontoTotal();
        }

        public void fill_data_by_notsend()
        {
            if (chk_t_fact.Checked)
            {
                dataGridView1.DataSource = get_Reportes.Get_Facturas_NoEnvidas();
                dataGridView1.Columns["id_FacturaElectronica"].Visible = false;
            }
            

            else{
                dataGridView1.DataSource = get_Reportes.Get_Tiquetes_NoEnviados();
                dataGridView1.Columns["id_TiqueteElectronico"].Visible = false;
            }
            
            CalcularMontoTotal();
        }

        public void fill_data_by_cancel()
        {
            string desde = cbDateDesde.Value.ToString("MM-dd-yyyy");
            DateTime Date_desde = DateTime.ParseExact(desde, "MM-dd-yyyy", null);

            string hasta = cbDateHasta.Value.ToString("MM-dd-yyyy");
            DateTime Date_hasta = DateTime.ParseExact(hasta, "MM-dd-yyyy", null);

            if (chk_t_fact.Checked)
            {
                dataGridView1.DataSource = get_Reportes.Get_Facturas_Cancelada(Date_desde, Date_hasta);
                dataGridView1.Columns["id_FacturaElectronica"].Visible = false;
            }


            else
            {
                dataGridView1.DataSource = get_Reportes.Get_Tiquetes_Cancelada(Date_desde, Date_hasta);
                dataGridView1.Columns["id_TiqueteElectronico"].Visible = false;
            }
            //CalcularMontoTotal();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rowView in dataGridView1.Rows)
            {
                try
                {
                    String DatosFact = rowView.Cells["xMLFacturaDataGridViewTextBoxColumn"].Value.ToString();
                    ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts", "POST", DatosFact, _owner.user, _owner.env);
                    string respose = request.GetResponse();
                    JObject o = JObject.Parse(respose);
                    string code = (string)o["code"];
                    if (code == "200" && chk_t_fact.Checked)
                    {
                        String NumFact = rowView.Cells["id_FacturaElectronica"].Value.ToString();
                        bool edit_respose = get_Reportes.Editar_Envio_Factura(Int32.Parse(NumFact), true);
                        if (edit_respose)
                        {
                            fill_data_by_notsend();
                            string message = (string)o["state-reason"];
                            MessageBox.Show("Factura enviada! Estado de la factura: " + message);
                        }
                    }
                    if (code == "200" && chk_t_tiquete.Checked)
                    {
                        String NumFact = rowView.Cells["id_TiqueteElectronico"].Value.ToString();
                        bool edit_respose = get_Reportes.Editar_Envio_Tiquete(Int32.Parse(NumFact), true);
                        if (edit_respose)
                        {
                            fill_data_by_notsend();
                            string message = (string)o["state-reason"];
                            MessageBox.Show("Tiquete enviado! Estado del tiquete: " + message);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error de Conexion: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lb_desde_Click(object sender, EventArgs e)
        {

        }

        private void cbDateDesde_ValueChanged(object sender, EventArgs e)
        {
            fill_data_by_date();
        }

        private void cbDateHasta_ValueChanged(object sender, EventArgs e)
        {
            fill_data_by_date();
        }

        private void chk_t_fact_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_t_fact.Checked)
            {
                chk_t_tiquete.Checked = false; 
            }
            else
            {
                chk_t_tiquete.Checked = true;
            }
            switched(chkEnv.Checked,chkDate.Checked,chk_cancelar.Checked);
        }

        private void chk_t_tiquet_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_t_tiquete.Checked)
            {

                chk_t_fact.Checked = false;
            }
            else
            {
                chk_t_fact.Checked = true;
            }
            switched(chkEnv.Checked, chkDate.Checked, chk_cancelar.Checked);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            string xmlstr = dataGridView1.Rows[e.RowIndex].Cells["xMLFacturaDataGridViewTextBoxColumn"].Value.ToString();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlstr);

            string result = "";
            if (chk_t_fact.Checked)
            {
                XmlNodeList receptor = xml.GetElementsByTagName("Nombre");
                result = result + "Enviada a: " + receptor[1].InnerXml + "\n\n";
            }

            XmlNodeList elemlist = xml.GetElementsByTagName("Detalle");

            result = result + "Productos vendidos:\n"; 
            for (int i = 0;  i< elemlist.Count; i++)
            {
                result = result + elemlist[i].InnerXml + "\n" ;
            }

            if (chkEnv.Checked)
            {
                FlexibleMessageBox.Show(result,
                              "Detalles de la factura");
            }
            else
            {
                var rest = FlexibleMessageBox.Show(result,
                 "Detalles de la factura",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1);
                

                if (rest.ToString() == "Yes")
                {
                    if (MessageBox.Show(" Estas seguro que deseas cancelar la venta? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        XmlNodeList Clave = xml.GetElementsByTagName("Clave");
                        string clave = Clave[0].InnerText;
                        ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts/cancel",clave,_owner.user, _owner.env);
                        string respose = request.GetResponse();
                        JObject o = JObject.Parse(respose);
                        string code = (string)o["code"];
                        if (code == "200")
                        {
                            bool edit_respose;
                            if (chk_t_fact.Checked)
                            {
                                string NumFact = dataGridView1.Rows[e.RowIndex].Cells["id_FacturaElectronica"].Value.ToString();
                                edit_respose = get_Reportes.Cancelar_Factura(Int32.Parse(NumFact));
                            }
                            else
                            {
                                string NumFact = dataGridView1.Rows[e.RowIndex].Cells["id_TiqueteElectronico"].Value.ToString();
                                edit_respose = get_Reportes.Cancelar_Ticket(Int32.Parse(NumFact));
                            }
                            if (edit_respose)
                            {
                                MessageBox.Show("Venta Cancelada");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hubo un error con la cancelación de la venta");
                        }
                    }
                }
                
            }
            fill_data_by_date();
        }

    }

}
