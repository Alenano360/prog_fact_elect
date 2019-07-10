using Newtonsoft.Json.Linq;
using PuntoVentaBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaPresentacion
{
    public partial class Inforacion_Hacienda : Form
    {
        public Sel_Mod _owner; 

        public Inforacion_Hacienda()
        {
            InitializeComponent();
        }

        private void Inforacion_Hacienda_Load(object sender, EventArgs e)
        {
            Load_Local_Config();
        }
        private void Load_Local_Config()
        {
            String rootpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            string path = rootpath + @"\Conf\serverconfig";

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                int line = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    if (line == 0)
                    {
                        txt_user_serv.text = s;
                    }
                    else {
                        txt_env.text = s;
                    }
                    line++;
                }
            }
        }

        private String Load_Key()
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos Binario|*.p12";
            openFileDialog1.Title = "Seleciones la llave";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                BinaryReader br;
                //reading from the file
                try
                {

                    Byte[] bytes = File.ReadAllBytes(openFileDialog1.FileName);
                    String key = Convert.ToBase64String(bytes);
                    return key;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    
                }
                return "";
            }
            return "";
        }
        

        private void btn_buscar_test_Click(object sender, EventArgs e)
        {
            txt_tst_llave.text = Load_Key();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            txt_prd_llave.text = Load_Key();
        }

        private void txt_user_serv_e(object sender, EventArgs e)
        {
            if (txt_user_serv.text == "Usuario Servidor")
            {
                txt_user_serv.text = "";
            }
            txt_user_serv.ForeColor = Color.Black;
        }

        private void txt_user_serv_l(object sender, EventArgs e)
        {
            if (txt_user_serv.text == "")
            {
                txt_user_serv.text = "Usuario Servidor";
            }
            txt_user_serv.ForeColor = Color.DarkGray;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String rootpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                string path = rootpath + @"\Conf\serverconfig";

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(txt_user_serv.text);
                    sw.WriteLine(txt_env.text);
                }
                _owner.user = txt_user_serv.text;
                _owner.env = txt_env.text;

                MessageBox.Show("Se han guardado los datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar los datos locales" + ex.ToString());
            }
            finally {
                Registrar_Prod();
                Registrar_Test();
            }
            
        }

        public void Registrar_Prod()
        {
            if (txt_prd_llave.text.Length != 0 &&
                txt_prd_clave.text.Length != 0 &&
                txt_prd_pin.text.Length != 0 &&
                txt_prd_usuario.text.Length != 0 )
            {
                string data = txt_prd_usuario.text  + " " + txt_prd_clave.text + " " + txt_prd_pin.text + " " + txt_prd_llave.text;
                ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/clients/production", "POST", data, "arojas","YH5kpJ8yN6",_owner.user);
                string respose = request.GetResponse();
                JObject o = JObject.Parse(respose);
                string code = (string)o["code"];
                if (code == "200")
                {
                    MessageBox.Show("Cliente Registrado Correctamente en el ambiente de Produccion");
                }
                else {
                    MessageBox.Show("No se pudo registrar los datos" + (string)o["code"]);
                }
            }
        }

        public void Registrar_Test()
        {
            if (txt_tst_llave.text.Length != 0 &&
                txt_tst_clave.text.Length != 0 &&
                txt_tst_pin.text.Length != 0 &&
                txt_tst_usuario.text.Length != 0)
            {
                string data = txt_tst_usuario.text + " " + txt_tst_clave.text + " " + txt_tst_pin.text + " " + txt_tst_llave.text;
                ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/clients/sandbox", "POST", data, "arojas", "YH5kpJ8yN6", _owner.user);
                string respose = request.GetResponse();
                JObject o = JObject.Parse(respose);
                string code = (string)o["code"];
                if (code == "200")
                {
                    MessageBox.Show("Cliente Registrado Correctamente en el ambiente de Pruebas");
                }
                else
                {
                    MessageBox.Show("No se pudo registrar los datos" + (string)o["code"]);
                }
            }
        }

        private void txt_prd_usuario_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_prd_clave_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_prd_pin_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_tst_llave_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_tst_usuario_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_tst_clave_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txt_tst_pin_OnTextChange(object sender, EventArgs e)
        {

        }
    }
}
