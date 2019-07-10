using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;


namespace PuntoVentaBL
{
    public class ImpresionPrefactura
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        public string Impresora = string.Empty;

        #region propiedades
        private decimal _IVA;

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
        }


        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }


        private string _Encabezado1;

        public string Encabezado1
        {
            get { return _Encabezado1; }
            set { _Encabezado1 = value; }
        }

        private string _Encabezado2;

        public string Encabezado2
        {
            get { return _Encabezado2; }
            set { _Encabezado2 = value; }
        }

        private string _Encabezado3;

        public string Encabezado3
        {
            get { return _Encabezado3; }
            set { _Encabezado3 = value; }
        }

        private string _Encabezado4;

        public string Encabezado4
        {
            get { return _Encabezado4; }
            set { _Encabezado4 = value; }
        }
        

        private decimal _subtotal;

        public decimal subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        private decimal _Impuesto;

        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }

        private string _Fecha;

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private decimal _Desc_Aplicado;

        public decimal Desc_Aplicado
        {
            get { return _Desc_Aplicado; }
            set { _Desc_Aplicado = value; }
        }

        private string _Hora;

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Dueno;

        public string Dueno
        {
            get { return _Dueno; }
            set { _Dueno = value; }
        }

        private string _Cedula;

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private string _PiePagina;

        public string PiePagina
        {
            get { return _PiePagina; }
            set { _PiePagina = value; }
        }
        private string _PiePagina2;

        public string PiePagina2
        {
            get { return _PiePagina2; }
            set { _PiePagina2 = value; }
        }
        private string _PiePagina3;

        public string PiePagina3
        {
            get { return _PiePagina3; }
            set { _PiePagina3 = value; }
        }
        private string _PiePagina4;

        public string PiePagina4
        {
            get { return _PiePagina4; }
            set { _PiePagina4 = value; }
        }
        private string _PiePagina5;

        public string PiePagina5
        {
            get { return _PiePagina5; }
            set { _PiePagina5 = value; }
        }

        private string _PiePagina6;
        public string PiePagina6
        {
            get { return _PiePagina6; }
            set { _PiePagina6 = value; }
        }
        private string _PiePagina7;
        public string PiePagina7
        {
            get { return _PiePagina7; }
            set { _PiePagina7 = value; }
        }
        private string _PiePagina8;
        public string PiePagina8
        {
            get { return _PiePagina8; }
            set { _PiePagina8 = value; }
        }

        private Int64 _FacturaId;

        public Int64 FacturaId
        {
            get { return _FacturaId; }
            set { _FacturaId = value; }
        }

        private string _ClienteNombre;

        public string ClienteNombre
        {
            get { return _ClienteNombre; }
            set { _ClienteNombre = value; }
        }

        private string _CajeroNombre;

        public string CajeroNombre
        {
            get { return _CajeroNombre; }
            set { _CajeroNombre = value; }
        }

        private decimal _TotalFactura;

        public decimal TotalFactura
        {
            get { return _TotalFactura; }
            set { _TotalFactura = value; }
        }

        public List<string> Articulos = new List<string>();

        public int Offset = 0;

        private int _Proforma;

        public int Proforma
        {
            get { return _Proforma; }
            set { _Proforma = value; }
        }

        #endregion

        #region metodos

        [DllImport("winspool.drv",
              CharSet = CharSet.Auto,
              SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetDefaultPrinter(String name);

        public void ObtieneInformacionGeneral()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           where x.Id == 1
                           select x).First();

                _Nombre = bus.Nombre;
                _Dueno = bus.Dueno;
                _Cedula = bus.Cedula;
                _Telefono = bus.Telefono;
                _Fax = bus.Fax;
                _IVA = Convert.ToDecimal(bus.IVA);
                _Encabezado1 = bus.Encabezado1;
                _Encabezado2 = bus.Encabezado2;
                _Encabezado3 = bus.Encabezado3;
                _Encabezado4 = bus.Encabezado4;
                _PiePagina = bus.PiePagina1;
                _PiePagina2 = bus.PiePagina2;
                _PiePagina3 = bus.PiePagina3;
                _PiePagina4 = bus.PiePagina4;
                _PiePagina5 = bus.PiePagina5;
                _PiePagina6 = bus.PiePagina6;
                _PiePagina7 = bus.PiePagina7;
                _PiePagina8 = bus.PiePagina8;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información general de la empresa: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void print()
        {
            string tempImpresorapred = string.Empty;
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ps.PrinterName = printer;
                if (ps.IsDefaultPrinter)
                {
                    Impresora = printer;
                    SetDefaultPrinter("PDFCreator");
                    break;
                }
            }

            PaperSize pkCustomSize1 = new PaperSize("8.5x11", 1100, 850);
          
            ps.DefaultPageSettings.PaperSize = pkCustomSize1;


            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            pd.Document = pdoc;

            DialogResult result = pd.ShowDialog();//
            if (result == DialogResult.OK)//
            {//
                PrintPreviewDialog pp = new PrintPreviewDialog();//
                pp.Document = pdoc;//
                result = pp.ShowDialog();//
                if (result == DialogResult.OK)//
                {//
                    pdoc.Print();//
                }//
            }//

            SetDefaultPrinter(Impresora);
            //pdoc.Print();
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Offset = 0;

            Graphics graphics = e.Graphics;

            int startX = 12;

            int startY = 25;

            this.ObtieneInformacionGeneral();

            Font stringFont = new Font("Times New Roman", 8, FontStyle.Bold);
            string measureString = string.Empty;
            stringFont = new Font("Times New Roman", 7);
            SizeF stringSize = new SizeF();
            SolidBrush sb = new SolidBrush(Color.Black);

            if (_Nombre.Length > 0)
            {
                graphics.DrawString(_Nombre.ToUpper(), new Font("Times New Roman", 13, FontStyle.Bold),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }

            if (_Dueno.Length > 0)
            {
                graphics.DrawString(_Dueno, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Cedula.Length > 0)
            {
                graphics.DrawString(_Cedula, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Telefono.Length > 0)
            {
                graphics.DrawString(_Telefono, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Fax.Length > 0)
            {
                graphics.DrawString(_Fax, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Encabezado1.Length > 0)
            {
                graphics.DrawString(_Encabezado1, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado2.Length > 0)
            {
                graphics.DrawString(_Encabezado2, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado3.Length > 0)
            {
                graphics.DrawString(_Encabezado3, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado4.Length > 0)
            {
                graphics.DrawString(_Encabezado4, new Font("Times New Roman", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 16;
            }

            graphics.DrawString("", new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            string x = "-----------------------------------";

            graphics.DrawString("Número de Prefactura: " + _FacturaId, new Font("Times New Roman", 10, FontStyle.Bold),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            measureString = "DOCUMENTO NO VÁLIDO COMO FACTURA";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
           // graphics.DrawString(measureString, new Font("Times New Roman", 6, FontStyle.Bold), sb, 820 - stringSize.Width - startX, startY + Offset);//total
            graphics.DrawString(measureString, new Font("Times New Roman", 8, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Cliente: " + _ClienteNombre, new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Fecha: " + _Fecha, new Font("Times New Roman", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(x + x + x + x + x + x, new Font("Times New Roman", 8),//------------------
                    new SolidBrush(Color.Black), startX + 5, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Times New Roman", 8, FontStyle.Bold);

            graphics.DrawString("CODIGO.", stringFont,
                    new SolidBrush(Color.Black), startX, startY + Offset);

            graphics.DrawString("DESCRIPCION.", stringFont,
                   new SolidBrush(Color.Black), startX+80, startY + Offset);

            //graphics.DrawString("UBICACION.", stringFont,
            //        new SolidBrush(Color.Black), startX + 80, startY + Offset);

            //graphics.DrawString("DESCRIPCION.", stringFont,
            //        new SolidBrush(Color.Black), startX + 160, startY + Offset);

            //graphics.DrawString("PRECIO.", stringFont,
            //        new SolidBrush(Color.Black), startX + 460, startY + Offset);

            //graphics.DrawString("CANTIDAD.", stringFont,
            //       new SolidBrush(Color.Black), startX + 545, startY + Offset);

            //graphics.DrawString("% DESC.", stringFont,
            //       new SolidBrush(Color.Black), startX + 645, startY + Offset);

            //graphics.DrawString("PRECIO TOTAL.", stringFont,
            //      new SolidBrush(Color.Black), startX + 710, startY + Offset);
            //Offset = Offset + 16;

          //  graphics.DrawString("PRECIO.", stringFont,
          //          new SolidBrush(Color.Black), startX + 80, startY + Offset);

            graphics.DrawString("CANT.", stringFont,
                    new SolidBrush(Color.Black), startX + 200, startY + Offset);

         //   graphics.DrawString("% DESC.", stringFont,
           //         new SolidBrush(Color.Black), startX + 200, startY + Offset);


            graphics.DrawString("TOTAL.", stringFont,
                    new SolidBrush(Color.Black), startX + 260, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(x + x + x + x + x + x, new Font("Times New Roman", 8),
                    new SolidBrush(Color.Black), startX + 5, startY + Offset);
            Offset = Offset + 16;


            foreach (string item in Articulos)
            {
                string[] temp = item.Split(';');

                measureString = string.Empty;
                stringFont = new Font("Times New Roman", 7);
                stringSize = new SizeF();
                sb = new SolidBrush(Color.Black);
                //temp[6]//ubicaicon
                graphics.DrawString(temp[0].ToUpper(), stringFont, sb, startX, startY + Offset);

                int i = temp[1].Count();
                if (i >16)
                {
                    graphics.DrawString(temp[1].ToUpper().Remove(16), stringFont, sb, startX+80, startY + Offset);
                }
                else
                {
                    graphics.DrawString(temp[1].ToUpper(), stringFont, sb, startX+80, startY + Offset);
                }

                measureString = temp[3].ToUpper();
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 240 - stringSize.Width, startY + Offset);//cant

           
                measureString = Convert.ToDecimal(temp[5].ToUpper()).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 315 - stringSize.Width - startX, startY + Offset);//total
                Offset = Offset + 16;
            }
            Offset = 725;
            graphics.DrawString(x + x + x + x + x + x, new Font("Times New Roman", 8),
                    new SolidBrush(Color.Black), startX + 5, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Times New Roman", 10, FontStyle.Bold);

            decimal montoiv = Convert.ToDecimal(_Impuesto);

            if (_Desc_Aplicado > 0)
            {
                //measureString = "SUBTOTAL:";
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, 720 - stringSize.Width, startY + Offset);

                //measureString = (Convert.ToDecimal(_subtotal + _Desc_Aplicado)).ToString("#,##.#0");
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, 820 - stringSize.Width - startX, startY + Offset);
                //Offset = Offset + 20;

                //measureString = "DESCUENTO:";
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, 700 - stringSize.Width, startY + Offset);


                //measureString = (Convert.ToDecimal(_Desc_Aplicado)).ToString("#,##.#0");
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, 820 - stringSize.Width - startX, startY + Offset);
                //Offset = Offset + 20;

                measureString = "SUBTOTAL:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 90 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_subtotal + _Desc_Aplicado)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;



                measureString = "DESCUENTO:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 100 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_Desc_Aplicado)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 190 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;


                measureString = "SUBTOTAL:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 90 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_subtotal)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;


                measureString = "IVA:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(montoiv)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "_______________________________";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "TOTAL:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_TotalFactura)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 70;

                measureString = "_______________________________";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "VENDEDOR:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80, startY + Offset);
                Offset = Offset + 20;

                measureString = _CajeroNombre.ToUpper();
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, ((265 - stringSize.Width) / 2), startY + Offset);
                Offset = Offset + 20;
            }
            else
            {
                measureString = "SUBTOTAL:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 90 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_subtotal)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "IVA:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(montoiv)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "_______________________________";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "TOTAL:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80 - stringSize.Width, startY + Offset);

                measureString = (Convert.ToDecimal(_TotalFactura)).ToString("#,##.#0");
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 180 - stringSize.Width - startX, startY + Offset);
                Offset = Offset + 70;

                measureString = "_______________________________";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);
                Offset = Offset + 20;

                measureString = "VENDEDOR:";
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, 80, startY + Offset);
                Offset = Offset + 20;

                measureString = _CajeroNombre.ToUpper();
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, ((265 - stringSize.Width) / 2), startY + Offset);
                Offset = Offset + 20;
            }
        }

        public void OpenConn()
        {
            if (db == null) db = new PuntoVentaDAL.CONEXIONDataContext();
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

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }
        #endregion
    }
}
