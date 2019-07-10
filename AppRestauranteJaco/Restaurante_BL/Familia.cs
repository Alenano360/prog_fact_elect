using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Restaurante_BL
{
    public class Familia
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private bool _EsGuarnicion;

        public bool EsGuarnicion
        {
            get { return _EsGuarnicion; }
            set { _EsGuarnicion = value; }
        }

        private bool _TieneGuarnicion;

        public bool TieneGuarnicion
        {
            get { return _TieneGuarnicion; }
            set { _TieneGuarnicion = value; }
        }
        
        #endregion  

        #region Metodos

        public void ObtieneFamilia(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Familias
                           where f.Activo == true
                           orderby f.Id descending
                           select new { f.Id, f.Descripcion });

                DataTable dt = new DataTable();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Descripcion");

                foreach (var item in bus)
                {
                    DataRow dre = dt.NewRow();
                    dre["Descripcion"] = item.Descripcion;
                    dre["Id"] = item.Id;
                    dt.Rows.InsertAt(dre, 0);
                }

                cmb.DisplayMember = "Descripcion";
                cmb.ValueMember = "Id";
                

                DataRow dr = dt.NewRow();
                dr["Descripcion"] = "--Seleccione--";
                dr["Id"] = 0;

                dt.Rows.InsertAt(dr, 0);
                cmb.DataSource = dt;
                cmb.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoFamilia(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Familias
                           where f.Activo == true
                           select new { f.Id, f.Descripcion, Guarnicion = (f.Guarnicion == true ? "SI" : "NO"), EsGuarnicion = (f.EsGuarnicion == true ? "SI" : "NO") });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool EliminaFamilia()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Familias
                           where x.Id == _Id
                           select x).First();

                bus.Activo = false;               

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }
            return true;
        }

        public void AgregaFamilia(PictureBox pic)
        {
            try
            {
                this.OpenConn();

                Restaurante_DAL.Familia _newFamilia = new Restaurante_DAL.Familia();
                _newFamilia.Descripcion = _Descripcion;

                byte[] file_byte = ImageToByteArray(pic.BackgroundImage);
                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                _newFamilia.Foto = file_binary;

                _newFamilia.EsGuarnicion = _EsGuarnicion;
                _newFamilia.Guarnicion = _TieneGuarnicion;
                _newFamilia.Activo = true;

                db.Familias.InsertOnSubmit(_newFamilia);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ModificaFamilia(PictureBox pic)
        {
            try
            {

                this.OpenConn();

                var _newFamilia = (from f in db.Familias
                               where f.Id == _Id
                               select f).First();

                _newFamilia.Descripcion = _Descripcion;

                Bitmap bm = new Bitmap(pic.BackgroundImage);
                byte[] file_byte = ImageToByteArray(bm);
                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                _newFamilia.Foto = file_binary;

                _newFamilia.EsGuarnicion = _EsGuarnicion;
                _newFamilia.Guarnicion = _TieneGuarnicion;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtengoDatosFamilia(PictureBox pic)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Familias
                           where f.Activo == true && f.Id==_Id
                           select f).First();

                _Descripcion = bus.Descripcion;
                _EsGuarnicion = Convert.ToBoolean(bus.EsGuarnicion);
                _TieneGuarnicion = Convert.ToBoolean(bus.Guarnicion);

                pic.BackgroundImage = null;
                pic.BackgroundImage = ByteArrayToImage(bus.Foto.ToArray());
                pic.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void CreoPanel(Panel pan)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.Familias
                          select x;

                int locx = 6;
                int locy = 5;

                foreach (var item in bus)
                {

                    Button btnFoto = new Button();
                    {
                        btnFoto.Name = "btn" + item.Descripcion.ToString();
                        btnFoto.Height = 110;
                        btnFoto.Width = 110;
                        btnFoto.Location = new Point(locx, locy);

                        Image imga = ByteArrayToImage(item.Foto.ToArray());

                        btnFoto.BackgroundImage = null;
                        btnFoto.BackgroundImage = ByteArrayToImage(item.Foto.ToArray());
                        btnFoto.BackgroundImageLayout = ImageLayout.Stretch;
                        btnFoto.FlatStyle = FlatStyle.Flat;
                        btnFoto.BackColor = Color.Transparent;

                        //btnFoto.Click += new EventHandler(btnRestaOrden);
                    }

                    locy += 130;

                    pan.Controls.Add(btnFoto);
                }







                //private void buttonStoreImageToDb_Click(object sender, EventArgs e)
                //{
                //    // Open the DataContext
                //    Database1 db = new Database1("Data Source=Database1.sdf");
                //    try
                //    {
                //        // Convert System.Drawing.Image to a byte[]
                //byte[] file_byte = ImageToByteArray(btn.BackgroundImage);
                ////        // Create a System.Data.Linq.Binary - this is what an "image" column is mapped to
                //System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);

                //var bus = from x in db.Familias
                //          where x.Id == 4
                //          select x;

                //bus.First().Foto = file_binary;
                //Restaurante_DAL.Familia img = new Restaurante_DAL.Familia();
                ////{
                //img.Foto = file_binary;
                //img.Descripcion = "Guarniciones";
                //img.Guarnicion = false;
                //img.EsGuarnicion = true;
                //img.Activo = true;

                ////};
                //db.Familias.InsertOnSubmit(img);
                //    }
                //    finally
                //    {
                //        // Save
                //db.SubmitChanges();
                //    }
                //}

                //private void buttonRetireveImageFromDb_Click(object sender, EventArgs e)
                //{
                //    // Open the DataContext
                //    Database1 db = new Database1("Data Source=Database1.sdf");

                //    // Get as single image from the database
                //    var img = (from image in db.Images
                //               where image.ImageName == "Erik testing"
                //               select image).Single();
                //    // Convert the byte[] to an System.Drawing.Image
                //    pictureBox1.Image = ByteArrayToImage(img.Image.ToArray());
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear y obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void CreoPanel2(Panel pan, Button btn)
        {
            try
            {
                this.OpenConn();

                var img = (from image in db.Familias
                           where image.Descripcion == "Erik testing"
                           select image).Single();

                Image imga = ByteArrayToImage(img.Foto.ToArray());

                // Convert the byte[] to an System.Drawing.Image

                Image re = ScaleImage(ByteArrayToImage(img.Foto.ToArray()), 110, 130);
                

                //btn.BackgroundImage = null;

                //btn.BackgroundImage = FixedSize(ByteArrayToImage(img.Foto.ToArray()), 100, 120);   

                btn.BackgroundImage=null;
                btn.BackgroundImage = imga;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar crear y obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
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

        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
        }

        public void CloseConn()
        {
            if (db != null)
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();

                db.Dispose();
                db = null;
            }
        }
        #endregion
    }
}
