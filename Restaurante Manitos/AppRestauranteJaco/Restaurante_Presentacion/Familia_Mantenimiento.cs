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
    public partial class Familia_Mantenimiento : Form
    {
        Familia_Mod _owner;
        Principal _owner1;

        public int FamiliaId = 0;

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        public Familia_Mantenimiento(Familia_Mod owner)
        {
            InitializeComponent();

            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Familia_Mod_Load(sender, e);
        }

        public Familia_Mantenimiento(Principal owner1)
        {
            InitializeComponent();

            _owner1 = owner1;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner1.Principal_Load(sender, e);
        }


        private void Familia_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                if (this.FamiliaId!=0)
                {
                    this.objFamilia.Id = this.FamiliaId;

                    this.objFamilia.ObtengoDatosFamilia(this.picFoto);

                    this.txtDescripcion.Text = this.objFamilia.Descripcion;

                    if (Convert.ToBoolean(this.objFamilia.EsGuarnicion))
                    {
                        this.chkEsGuarnicion.Checked=true;
                    }
                    else
                    {
                        this.chkEsGuarnicion.Checked = false;
                    }

                    if (Convert.ToBoolean(this.objFamilia.TieneGuarnicion))
                    {
                        this.chkTieneGuarnicion.Checked = true;
                    }
                    else
                    {
                        this.chkTieneGuarnicion.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al mantenimiento de las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.txtDescripcion.Text.Length==0||this.txtDescripcion.Text=="")
            {
                MessageBox.Show("Por favor digite la descripción de la familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = this.txtDescripcion;
                return;
            }
            if (this.picFoto.BackgroundImage==null)
            {
                MessageBox.Show("Por favor seleccione una foto de la familia", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.objFamilia.Descripcion = this.txtDescripcion.Text;

            this.objFamilia.EsGuarnicion = Convert.ToBoolean(this.chkEsGuarnicion.CheckState);
            this.objFamilia.TieneGuarnicion = Convert.ToBoolean(this.chkTieneGuarnicion.CheckState);

            DialogResult result;

            if (this.FamiliaId != 0)
            {
                this.objFamilia.Id = this.FamiliaId;
                result = MessageBox.Show("¿Está seguro que desea modificar la familia?", "Confirmación", MessageBoxButtons.OKCancel);
            }
            else
            {
                result = MessageBox.Show("¿Está seguro que desea agregar la familia?", "Confirmación", MessageBoxButtons.OKCancel);
            }
            

            if (result == DialogResult.OK)
            {
                if (this.FamiliaId != 0)
                {
                    this.objFamilia.ModificaFamilia(this.picFoto);

                    MessageBox.Show("Familia modificada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.objFamilia.AgregaFamilia(this.picFoto);

                    MessageBox.Show("Familia agregada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }

        private void btnSeleccionaFoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
                openFileDialog1.ShowDialog();

                this.picFoto.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                this.picFoto.BackgroundImageLayout = ImageLayout.Stretch;
                
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
    }
}
