using PuntoVentaBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaPresentacion
{
    public partial class AgregarPersona : Form
    {
        public Mantenimiento_Persona _owner;
        public Elegir_Persona _owner2;
        PuntoVentaBL.Persona _DTO_Persona = new PuntoVentaBL.Persona();
        PuntoVentaBL.CR_Ubicacion mod = new PuntoVentaBL.CR_Ubicacion();

        public AgregarPersona()
        {
            InitializeComponent();
            

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_owner != null)
            {
                this._owner.Show();
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        public bool ValidarCorreo(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Int32.Parse(txt_ident_num.text);
                string cantonid = mod.getCantonId(Int32.Parse(cb_Canton.SelectedValue.ToString()));
                if (ValidarCorreo(txt_correo.text))
                {

                    Persona Nuevo_Receptor = new Persona();
                    Nuevo_Receptor.Nombre = txt_nombre.text;
                    Nuevo_Receptor.CorreoElectronico = txt_correo.text;
                    Nuevo_Receptor.Ident_Tipo = ((KeyValuePair<string, string>)cb_ident_tipo.SelectedItem).Key;
                    Nuevo_Receptor.Ident_Numero = txt_ident_num.text;
                    Nuevo_Receptor.Ubi_Provicia = cb_Provincia.SelectedValue.ToString();
                    if (cantonid.Length == 1) { cantonid = "0" + cantonid; }
                    Nuevo_Receptor.Ubi_Canton = cantonid;
                    string Distrito = cb_Distrito.SelectedValue.ToString();
                    if (Distrito.Length == 1) { Distrito = "0" + Distrito; }
                    Nuevo_Receptor.Ubi_Distrito = Distrito;
                    Nuevo_Receptor.Ubi_OtrasSenas = txt_Ot_S.text;
                    Nuevo_Receptor.Tel_NumeroTelefono = "0";
                    Nuevo_Receptor.Fax_NumeroTelefono = "0";

                    if (_DTO_Persona.AgregarPersona(Nuevo_Receptor, cb_emisor.Checked))
                    {
                        MessageBox.Show("Persona agregarda con exito");
                        if (_owner != null)
                        {
                            _owner.Mantenimiento_Persona_Load();
                        }
                        else
                        {
                            _owner2.ReLoadView();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al agregar la persona, no se puede agregar mas de un emisor.");
                    }
                }
                else
                {
                    MessageBox.Show("Formato de correo invalido!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de la cedula invalido, solo se permiten numeros");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido agergar a la persona" + ex);
            }
        }

        private void txt_nombre_hint(object sender, EventArgs e)
        {
            if (txt_nombre.text == "Nombre") {
                txt_nombre.text = ""; 
            }
            txt_nombre.ForeColor = Color.Black; 
        }

        private void txt_nombre_leave(object sender, EventArgs e)
        {
            if (txt_nombre.text == "")
            {
                txt_nombre.text = "Nombre";
            }
            txt_nombre.ForeColor = Color.DarkGray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_ident_tipo_e(object sender, EventArgs e)
        {

        }

        private void txt_ident_tipo_l(object sender, EventArgs e)
        {

        }

        private void txt_ident_num_e(object sender, EventArgs e)
        {
            if (txt_ident_num.text == "Número")
            {
                txt_ident_num.text = "";
            }
            txt_ident_num.ForeColor = Color.Black;
        }

        private void txt_ident_num_l(object sender, EventArgs e)
        {
            if (txt_ident_num.text == "")
            {
                txt_ident_num.text = "Número";
            }
            txt_ident_num.ForeColor = Color.DarkGray;
        }

        private void txt_Ot_S_e(object sender, EventArgs e)
        {
            if (txt_Ot_S.text == "Otras señas")
            {
                txt_Ot_S.text = "";
            }
            txt_Ot_S.ForeColor = Color.Black;
        }

        private void txt_Ot_S_l(object sender, EventArgs e)
        {
            if (txt_Ot_S.text == "")
            {
                txt_Ot_S.text = "Otras señas";
            }
            txt_Ot_S.ForeColor = Color.DarkGray;
        }

        private void txt_correo_e(object sender, EventArgs e)
        {
            if (txt_correo.text == "Correo")
            {
                txt_correo.text = "";
            }
            txt_correo.ForeColor = Color.Black;
        }

        private void txt_correo_l(object sender, EventArgs e)
        {
            if (txt_correo.text == "")
            {
                txt_correo.text = "Correo";
            }
            txt_correo.ForeColor = Color.DarkGray;
        }

       



        private void txt_ident_num_OnTextChange(object sender, EventArgs e)
        {

        }

        private void AgregarPersona_Load(object sender, EventArgs e)
        {


            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("01", "Cedula Nacional");
            test.Add("02", "Cedula Juridica");
            cb_ident_tipo.DataSource = new BindingSource (test, null);
            cb_ident_tipo.DisplayMember = "Value";
            cb_ident_tipo.ValueMember = "Key";

            mod.LoadProvincia(cb_Provincia);
            mod.LoadCanton(cb_Canton, Int32.Parse(cb_Provincia.SelectedValue.ToString()));
            mod.LoadDistrito(cb_Distrito, Int32.Parse(cb_Canton.SelectedValue.ToString()), Int32.Parse(cb_Provincia.SelectedValue.ToString()));
        }

        private void cb_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mod.LoadCanton(cb_Canton, Int32.Parse(cb_Provincia.SelectedValue.ToString()));
            }
            catch {

            }
       }
        private void cb_Distrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mod.LoadDistrito(cb_Distrito, Int32.Parse(cb_Canton.SelectedValue.ToString()), Int32.Parse(cb_Provincia.SelectedValue.ToString()));
            }
            catch {
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cb_Distrito_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void txt_correo_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cb_emisor_OnChange(object sender, EventArgs e)
        {

        }
    }
}
