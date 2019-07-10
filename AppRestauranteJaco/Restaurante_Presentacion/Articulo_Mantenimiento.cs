using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Restaurante_Presentacion
{
    public partial class Articulo_Mantenimiento : Form
    {
        Articulo_Mod _owner;

        Principal _owner1;

        public int ArticuloId = 0;

        Restaurante_BL.Articulo objArticulo = new Restaurante_BL.Articulo();

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        String familia;
        String nombre;
        String descripcion;
        double costo;
        int existencia;
        bool inventeriado;
        int tipo_cargar;

 


        public Articulo_Mantenimiento(Articulo_Mod owner)
        {
            InitializeComponent();

            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Articulo_Mod_Load(sender, e);
        }

        public Articulo_Mantenimiento(Principal owner1)
        {
            InitializeComponent();

            _owner1 = owner1;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner1.Principal_Load(sender, e);
        }

        public void llenar_combo() {

           this.comboBox1.Items.Add("--Seleccione--");
            this.comboBox1.Items.Add("Normal");
            this.comboBox1.Items.Add("Genérico");

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                if (comboBox1.GetItemText(comboBox1.Items[i]) == "--Seleccione--")
                {
                    comboBox1.SelectedIndex = i;
                   
                }
            }
            
            
        }
        private void Familia_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                llenar_combo();
                this.BringToFront();

                this.objFamilia.ObtieneFamilia(this.cmbFamilia);

                this.cmbComanda.Text = "--Seleccione--";

                if (this.ArticuloId!=0)
                {
                    this.objArticulo.Id = this.ArticuloId;
                   // MessageBox.Show("EL CODIGO ES " + this.objArticulo.Id);

                    this.objArticulo.ObtengoDatosArticulos();

                    this.txtNombre.Text = this.objArticulo.Nombre;

                    this.txtDescripcion.Text = this.objArticulo.Descripcion;

                    this.cmbFamilia.SelectedValue = this.objArticulo.FamiliaId;

                    this.txtCosto.Text = this.objArticulo.Costo.ToString("F");

                    this.txtExistencias.Text = this.objArticulo.Existencias.ToString();

                    tipo_cargar = Convert.ToInt32(this.objArticulo.Tipo);

                    //vamos a darle el valor al combo de tipo
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                        if (tipo_cargar == 1)
                        {
                            if (comboBox1.GetItemText(comboBox1.Items[i]) == "Normal")
                            {
                                comboBox1.SelectedIndex = i;

                            }
                        }
                    }
                    //******************************************
                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                        if (tipo_cargar == 2)
                        {
                            if (comboBox1.GetItemText(comboBox1.Items[i]) == "Genérico")
                            {
                                comboBox1.SelectedIndex = i;

                            }
                        }
                    }
                    //******************************************

                    if (this.objArticulo.Inventariado==true)
                    {
                        this.chkInventariado.Checked = true;
                    }
                    else
                    {
                        this.chkInventariado.Checked = false;
                    }

                    if (this.objArticulo.Comanda==1)
                    {
                        this.cmbComanda.Text = "BAR";
                    }
                    else
                    {
                        this.cmbComanda.Text = "COCINA";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al mantenimiento del artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Familia_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Length == 0 || this.txtNombre.Text == "")
            {
                MessageBox.Show("Por favor digite el nombre del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.txtNombre;
                return;
            }
            if (this.txtDescripcion.Text.Length == 0 || this.txtDescripcion.Text == "")
            {
                MessageBox.Show("Por favor digite la descripción del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.txtDescripcion;
                return;
            }
            if (this.cmbFamilia.Text=="--Seleccione--")
            {
                MessageBox.Show("Por favor seleccione la familia del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.cmbFamilia;
                return;
            }
            if (this.txtCosto.Text.Length == 0 || this.txtCosto.Text == "")
            {
                MessageBox.Show("Por favor digite el costo del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try
                {
                    decimal x = 0;

                    x = Convert.ToDecimal(this.txtCosto.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor digite solo números para el costo del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.ActiveControl = this.txtCosto;
                return;
            }

            if (this.txtExistencias.Text.Length == 0 || this.txtExistencias.Text == "")
            {
                MessageBox.Show("Por favor digite las existencias del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try
                {
                    decimal x = 0;

                    x = Convert.ToDecimal(this.txtExistencias.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Por favor digite solo números para las existencias del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.ActiveControl = this.txtExistencias;
                return;
            }
            if (this.cmbComanda.Text == "--Seleccione--")
            {
                MessageBox.Show("Por favor seleccione la comanda del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.cmbComanda;
                return;
            }

            if (this.comboBox1.Text == "--Seleccione--")
            {
                MessageBox.Show("Por favor seleccione el tipo del artículo", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.comboBox1;
                return;
            }

            this.objArticulo.Nombre = this.txtNombre.Text;
            this.objArticulo.Descripcion = this.txtDescripcion.Text;
            this.objArticulo.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());
            this.objArticulo.Costo = Convert.ToDecimal(this.txtCosto.Text);
            this.objArticulo.Existencias = Convert.ToInt32(this.txtExistencias.Text);

            if (this.chkInventariado.Checked)
            {
                this.objArticulo.Inventariado = true;

            }
            else
            {
                this.objArticulo.Inventariado = false;
            }

            if (this.cmbComanda.Text=="BAR")
            {
                this.objArticulo.Comanda = 1;
            }
            else
            {
                this.objArticulo.Comanda = 2;
            }

            DialogResult result;

            if (this.ArticuloId != 0)
            {
                this.objArticulo.Id = this.ArticuloId;
                result = MessageBox.Show("¿Está seguro que desea modificar el artículo?", "Confirmación", MessageBoxButtons.OKCancel);
            }
            else
            {
                result = MessageBox.Show("¿Está seguro que desea agregar el artículo?", "Confirmación", MessageBoxButtons.OKCancel);
            }


            if (result == DialogResult.OK)
            {
                if (this.ArticuloId != 0)
                {
                    //Genérico
                    if (comboBox1.Text == "Genérico")
                    {
                        this.objArticulo.Tipo = 2;
                    }
                    else
                    {
                        this.objArticulo.Tipo = 1;
                    }
                    this.objArticulo.ModificaArticulo();

                    MessageBox.Show("Artículo modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (this.comboBox1.Text == "Normal")
                    {
                        this.objArticulo.Tipo=1;
                        this.objArticulo.AgregaArticulo();
                        MessageBox.Show("Artículo agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Restaurante_BL.Metodos mantenimientos = new Restaurante_BL.Metodos();
                    String respuesta;
                    String query="";
                    if (this.comboBox1.Text == "Genérico")
                    {
                        bool activo=true;
                        query = "sp_ingresar_articulos '" + cmbFamilia.Text + "','"
                            + this.objArticulo.Nombre + "','" + this.objArticulo.Descripcion + "'," + this.objArticulo.Costo
                            + "," + this.objArticulo.Existencias + "," + this.objArticulo.Inventariado + "," 
                            + this.objArticulo.Comanda+","+activo+"";
                        respuesta = mantenimientos.ingresar_articlos(query);
                        MessageBox.Show(respuesta, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                   
                }

                this.Close();
            }
        }

        private void btnSeleccionaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.bmp; *.png";
                openFileDialog1.ShowDialog();

                //this.picFoto.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                //this.picFoto.BackgroundImageLayout = ImageLayout.Stretch;
                
            }
            catch (Exception)
            {
            }
        }

        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Genérico")
            {
                txtCosto.Text = "0.00";
                txtCosto.Enabled = false;
            }
            else
            {
                txtCosto.Enabled = true;

            }
        }
    }
}
