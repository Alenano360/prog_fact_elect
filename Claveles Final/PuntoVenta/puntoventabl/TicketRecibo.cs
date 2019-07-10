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
   public class TicketRecibo
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        public string Impresora = string.Empty;

        #region propiedades

   

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

  

        private int _Reimpresion;

        public int Reimpresion
        {
            get { return _Reimpresion; }
            set { _Reimpresion = value; }
        }
       



        private int _AltoPapel;

        public int AltoPapel
        {
            get { return _AltoPapel; }
            set { _AltoPapel = value; }
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

        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
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

        private DateTime _FechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }
     
        private Int64 _ReciboId;

        public Int64 ReciboId
        {
            get { return _ReciboId; }
            set { _ReciboId = value; }
        }

        private string _ClienteCedula;

        public string ClienteCedula
        {
            get { return _ClienteCedula; }
            set { _ClienteCedula = value; }
        }

        private string _ClienteNombre;

        public string ClienteNombre
        {
            get { return _ClienteNombre; }
            set { _ClienteNombre = value; }
        }

        private string _TotalLetras;

        public string TotalLetras
        {
            get { return _TotalLetras; }
            set { _TotalLetras = value; }
        }

        private decimal _Total;

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _Concepto;

        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }

        }

        private decimal _SaldoAnterior;

        public decimal SaldoAnterior
        {
            get { return _SaldoAnterior; }
            set { _SaldoAnterior = value; }
        }

        private decimal _Abono;

        public decimal Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }


        private decimal _SaldoActual;

        public decimal SaldoActual
        {
            get { return _SaldoActual; }
            set { _SaldoActual = value; }
        }

        private string _TipoRecibo;

        public string TipoRecibo
        {
            get { return _TipoRecibo; }
            set { _TipoRecibo = value; }

        }

        private string _NumCuenta;

        public string NumCuenta
        {
            get { return _NumCuenta; }
            set { _NumCuenta = value; }

        }

       
        public int Offset = 0;

     #endregion

     #region metodos
        [DllImport("winspool.drv",
              CharSet = CharSet.Auto,
              SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetDefaultPrinter(String name);


        decimal publicwidth = 0;

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
            //SetDefaultPrinter(Impresora);

            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ps.PrinterName = printer;
                if (ps.IsDefaultPrinter)
                {
                    Impresora = printer;
                }
            }
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            //pdoc.PrinterSettings.PrinterName = Impresora;

            //publicwidth = pdoc.DefaultPageSettings.PaperSize.Width;

            //MessageBox.Show(publicwidth.ToString());

            pd.Document = pdoc;


            //DialogResult result = pd.ShowDialog();//
            //if (result == DialogResult.OK)//
            //{//
            //    PrintPreviewDialog pp = new PrintPreviewDialog();//
            //    pp.Document = pdoc;//
            //    result = pp.ShowDialog();//
            //    if (result == DialogResult.OK)//
            //    {//
            //        pdoc.Print();//
            //    }//
            //}//

            pdoc.Print();
        }



        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
          
            Offset = 0;

            Font stringFont = new Font("Merchant Copy Doublesize", 7);
            string measureString = string.Empty;
            SizeF stringSize = new SizeF();
            SolidBrush sb = new SolidBrush(Color.Black);

            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;

            int startX = 5;
            //int startY = -100;
            int startY = 0;


            this.OpenConn();

            var bus = from ig in db.InformacionGeneral
                      select ig;

            this.ObtieneInformacionGeneral();

            if (_Nombre.Length > 0)
            {
                measureString = _Nombre.ToUpper();
                stringSize = e.Graphics.MeasureString(measureString, new Font("Merchant Copy Doublesize", 11));
                graphics.DrawString(measureString, new Font("Merchant Copy Doublesize", 11), sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 20;
            }

            stringFont = new Font("Merchant Copy Doublesize", 7);

            if (_Dueno.Length > 0)
            {
                measureString = _Dueno;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Cedula.Length > 0)
            {
                measureString = _Cedula;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Telefono.Length > 0)
            {
                measureString = _Telefono;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }

            if (_Encabezado1.Length > 0)
            {
                measureString = _Encabezado1;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado2.Length > 0)
            {
                measureString = _Encabezado2;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado3.Length > 0)
            {
                measureString = _Encabezado3;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }
            if (_Encabezado4.Length > 0)
            {
                measureString = _Encabezado4;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }


            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            string NumRecibo=" ";
            if (_ReciboId < 10)
            {
                NumRecibo = "00" + Convert.ToString(_ReciboId);
            }
            else if (_ReciboId >= 10)
            {
                NumRecibo = "0" + Convert.ToString(_ReciboId);
            }

            if (_FechaCreacion != Convert.ToDateTime("01/01/001"))
            {
                graphics.DrawString("Fecha: " +_FechaCreacion.ToShortDateString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX+170, startY + Offset);
                Offset = Offset + 16;
            }
            else
            {
                graphics.DrawString("Fecha: " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString(), new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX+170, startY + Offset);
                Offset = Offset + 16;
            }

            graphics.DrawString("RECIBO POR DINERO Nº: " + NumRecibo, new Font("Merchant Copy Doublesize", 7),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;           
          
            string x = "_________________________________________________";

            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 8),//------------------
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("RECIBIMOS DE: " + _ClienteNombre, new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("CED Nº : " + _ClienteCedula, new Font("Merchant Copy Doublesize", 8),
                   new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(" ", new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("LA SUMA DE: " + _TotalLetras, new Font("Merchant Copy Doublesize", 7),
                 new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
        

            graphics.DrawString("₡   " + _Total, new Font("Merchant Copy Doublesize", 8),
                new SolidBrush(Color.Black), startX+170, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(" ", new Font("Merchant Copy Doublesize", 8),//------------------
                   new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("POR CONCEPTO DE: " +_Concepto, new Font("Merchant Copy Doublesize", 7),
                 new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(" ", new Font("Merchant Copy Doublesize", 8),//------------------
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),
                 new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Saldo Anterior ₡" + _SaldoAnterior, new Font("Merchant Copy Doublesize", 8),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

          
            graphics.DrawString("Abono              ₡" + _Abono, new Font("Merchant Copy Doublesize", 8),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("Saldo Actual   ₡" + _SaldoActual, new Font("Merchant Copy Doublesize", 8),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 7),
                 new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString("Nº_BCO___" + _NumCuenta+"__", new Font("Merchant Copy Doublesize", 6),
                        new SolidBrush(Color.Black), startX, startY + Offset);           
            if (_TipoRecibo == "Efectivo")
            {
                graphics.DrawString("EFECT [X]"+"  "+"CK [ ]", new Font("Merchant Copy Doublesize", 7),
               new SolidBrush(Color.Black), startX + 170, startY + Offset);
                Offset = Offset + 16;
            }

            if (_TipoRecibo == "Cheque")
            {
                graphics.DrawString("EFECT [ ]"+"  "+ "CK [X]", new Font("Merchant Copy Doublesize", 7),
               new SolidBrush(Color.Black), startX + 170, startY + Offset);
                Offset = Offset + 16;
            }

            graphics.DrawString(" ", new Font("Merchant Copy Doublesize", 8),//------------------
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            string x2 = "________________________";
            graphics.DrawString(x2, new Font("Merchant Copy Doublesize", 8),
                 new SolidBrush(Color.Black), startX+40, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString("FIRMA AUTORIZADA", new Font("Merchant Copy Doublesize", 7),
                new SolidBrush(Color.Black), startX+80, startY + Offset);
            Offset = Offset + 16;

          
           
                stringFont = new Font("Merchant Copy Doublesize", 6);

                if (_PiePagina.Length > 0)
                {
                    measureString = _PiePagina;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina2.Length > 0)
                {
                    measureString = _PiePagina2;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina3.Length > 0)
                {
                    measureString = _PiePagina3;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }

                if (_PiePagina4.Length > 0)
                {
                    measureString = _PiePagina4;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_PiePagina5.Length > 0)
                {
                    measureString = _PiePagina5;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_PiePagina6.Length > 0)
                {
                    measureString = _PiePagina6;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_PiePagina7.Length > 0)
                {
                    measureString = _PiePagina7;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
                }
                if (_PiePagina8.Length > 0)
                {
                    measureString = _PiePagina8;
                    stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                    Offset = Offset + 16;
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
