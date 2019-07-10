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
    public partial class ConfguracionFacturaElectronica : Form
    {


        public ConfguracionFacturaElectronica()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Guardar id cliente 
            this.updateTable("DMClientID", this.textBox1.Text);

        }


        private bool updateTable( String field, String value)
        {
            String query = "update DGTDConfig set " + field + " = ? where id = 1;";
            return false; 
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            // open view to load p12 file 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //acutalizar info remote server

        }

        //Sends post request to server
        private bool updateRemoteServerInfo()
        {
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update de info de emisor

        }
        
        //Check de sandbox o pruebas onChange event
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ( this.radioButton2.Checked)
            {
                this.radioButton1.Checked = true; 
            }
        }


    }
}
