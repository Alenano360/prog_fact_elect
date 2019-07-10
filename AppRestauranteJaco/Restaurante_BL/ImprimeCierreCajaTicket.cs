using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Restaurante_BL
{

    public class ImprimeCierreCajaTicket
    {
        Restaurante_DAL.BaseDatosDataContext db = null;
        public string Impresora = string.Empty;

        #region propiedades
        private decimal _IVA;

        public decimal IVA
        {
            get { return _IVA; }
            set { _IVA = value; }
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
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }


        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
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

        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _PiePagina1;

        public string PiePagina1
        {
            get { return _PiePagina1; }
            set { _PiePagina1 = value; }
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
        private string _FinalPagina;

        public string FinalPagina
        {
            get { return _FinalPagina; }
            set { _FinalPagina = value; }
        }

        private decimal _TipoCambio;

        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }

        private decimal _ImpuestoServicio;

        public decimal ImpuestoServicio
        {
            get { return _ImpuestoServicio; }
            set { _ImpuestoServicio = value; }
        }

        private string _Web;

        public string Web
        {
            get { return _Web; }
            set { _Web = value; }
        }

        public List<string> INGRESOS = new List<string>();

        public List<string> EGRESOS = new List<string>();

        public int Offset = 0;

        #endregion

        #region metodos

        [DllImport("winspool.drv",
              CharSet = CharSet.Auto,
              SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetDefaultPrinter(String name);
        decimal InicioCajaDiaria = 0;
        decimal efectivo;
        decimal tarjeta;
        decimal VENTASTOTALESCajadiaria = 0;
        public void ObtieneInformacionGeneral()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                if (bus.Count() > 0)
                {
                    var bu = bus.First();

                    _Nombre = bu.Nombre;
                    _Dueno = bu.Dueno;
                    _Cedula = bu.Cedula;
                    _Telefono = bu.Telefono;
                    _Fax = bu.Fax;
                    _PiePagina1 = bu.PiePagina1;
                    _PiePagina2 = bu.PiePagina2;
                    _PiePagina3 = bu.PiePagina3;
                    _PiePagina4 = bu.PiePagina4;
                    _FinalPagina = bu.FinalPagina;
                    _Web = bu.Web;
                    _IVA = Convert.ToDecimal(Convert.ToDecimal(bu.IVA).ToString("F"));
                    _ImpuestoServicio = Convert.ToDecimal(Convert.ToDecimal(bu.ImpuestoServicio).ToString("F"));
                    _TipoCambio = Convert.ToDecimal(Convert.ToDecimal(bu.TipoCambio).ToString("F"));
                }
                else
                {
                    _Nombre = "";
                    _Dueno = "";
                    _Cedula = "";
                    _Telefono = "";
                    _Fax = "";
                    _PiePagina1 = "";
                    _PiePagina2 = "";
                    _PiePagina3 = "";
                    _PiePagina4 = "";
                    _FinalPagina = "";
                    _Web = "";
                    _IVA = 0;
                    _ImpuestoServicio = 0;
                    _TipoCambio = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }


        decimal publicwidth = 0;

        public void print(decimal DineroApertura, decimal VentasTotales, decimal efectivo, decimal tarjeta)
        {
            //DESKTOP-T8EF46F
            InicioCajaDiaria = DineroApertura;
            VENTASTOTALESCajadiaria = VentasTotales;

            this.efectivo = efectivo;
            this.tarjeta = tarjeta;

            //MessageBox.Show("Ventas totales "+VENTASTOTALESCajadiaria+" efectivo "+this.efectivo+" tarjeta "+this.tarjeta);
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                ps.PrinterName = printer;
                if (ps.IsDefaultPrinter)
                {
                    //  Impresora = @"\" + @"\" + "ELVIEJOSERVER";
                    Impresora = "impresoracomandacocina";

                }
            }
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);


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
            string Impresora = string.Empty;

            Graphics graphics = e.Graphics;

            int startX = 5;
            //int startY = -100;
            int startY = 0;

            this.ObtieneInformacionGeneral();

            Font stringFont = new Font("Merchant Copy Doublesize", 7);
            string measureString = string.Empty;
            SizeF stringSize = new SizeF();
            SolidBrush sb = new SolidBrush(Color.Black);

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

            if (_Fax.Length > 0)
            {
                measureString = _Fax;
                stringSize = e.Graphics.MeasureString(measureString, stringFont);
                graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
                Offset = Offset + 16;
            }

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString(System.DateTime.Now.ToString(), new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Merchant Copy Doublesize", 7);

            measureString = "CIERRE DE CAJA";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 32;

            measureString = "INGRESOS DE CAJA";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width) / 2, startY + Offset);
            Offset = Offset + 32;

            string x = "-------------------------------------";
            string underline = "------------";

            this.OpenConn();

            decimal TOTALINGRESOS = 0;

            //var APERTURA = (from cd in db.CajaDiarias
            //                where cd.Activo == true && cd.Visible == true
            //                   && (cd.MovimientoId == 1)
            //                orderby cd.Id descending
            //                select new { cd.Saldo }).First();

            // String costo = APERTURA.Saldo.ToString();
            //   MessageBox.Show("La apertura es " + costo);

            //  TOTALINGRESOS += APERTURA.Saldo;

            stringFont = new Font("Merchant Copy Doublesize", 7);

            graphics.DrawString("APERTURA DE CAJA", stringFont, sb, startX, startY + Offset);
            measureString = InicioCajaDiaria.ToString("##,#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 32;

            var VENTAS = from cd in db.CajaDiarias
                         join eq in db.Equipos on cd.EquipoId equals eq.Id
                         join fe in db.FacturaEncabezado on cd.ComprobanteId equals fe.Id into ps
                         from fe in ps.DefaultIfEmpty()
                         //where cd.Activo==true && cd.Visible==true && ((cd.MovimientoId==2 && fe.TipoPago==2) ||cd.MovimientoId==6||cd.MovimientoId==10)
                         where cd.Activo == true && cd.Visible == true &&
                         (cd.MovimientoId == 2 && !cd.Descripcion.Contains("tarjeta de crédito")) &&
                             //Se agregan filtros para cajas: 18/12/2015:
                          eq.NombreEquipo == System.Environment.MachineName.ToString()
                         select new { cd.Hora, fe.Id, cd.Monto };

            decimal totalventas = 0;
            //efectivo

            //  if (VENTAS.Count() > 0)

            // {
            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString("VENTAS EN EFECTIVO", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Merchant Copy Doublesize", 7);

            totalventas = 0;

            foreach (var item in VENTAS)
            {
                //graphics.DrawString(item.Hora + "-Venta", stringFont, sb, startX, startY + Offset);
                //graphics.DrawString(item.Id.ToString(), stringFont, sb, startX + 125, startY + Offset);
                //measureString = item.Monto.ToString("##,#0");
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
                //Offset = Offset + 16;

                totalventas += item.Monto;
            }
            //underline

            measureString = underline;
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 16;

            //  MessageBox.Show("Total ventas efectivo programa " + totalventas+" jean "+efectivo);

            graphics.DrawString("TOTAL VTAS. EFECT.", stringFont, sb, startX, startY + Offset);
            measureString = efectivo.ToString("##,#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 32;

            //  }

            var VENTASTARJETA = from cd in db.CajaDiarias
                                join eq in db.Equipos on cd.EquipoId equals eq.Id
                                join fe in db.FacturaEncabezado on cd.ComprobanteId equals fe.Id into ps
                                from fe in ps.DefaultIfEmpty()
                                //where cd.Activo==true && cd.Visible==true && ((cd.MovimientoId==2 && fe.TipoPago==2) ||cd.MovimientoId==6||cd.MovimientoId==10)
                                where cd.Activo == true && cd.Visible == true && cd.MovimientoId == 2 &&
                                cd.Descripcion.Contains("tarjeta de crédito") &&
                                    //Se agregan filtros para cajas: 18/12/2015:
                                eq.NombreEquipo == System.Environment.MachineName.ToString()
                                select new { cd.Hora, fe.Id, cd.Monto };

            //if (VENTASTARJETA.Count() > 0)
            //{
            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString("VENTAS EN TARJETA", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;
            graphics.DrawString(x, new Font("Merchant Copy Doublesize", 8),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            graphics.DrawString("", new Font("Merchant Copy Doublesize", 7),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 16;

            stringFont = new Font("Merchant Copy Doublesize", 7);

            decimal totalventastarjeta = 0;

            foreach (var item in VENTASTARJETA)
            {
                //graphics.DrawString(item.Hora + "-Venta", stringFont, sb, startX, startY + Offset);
                //graphics.DrawString(item.Id.ToString(), stringFont, sb, startX + 125, startY + Offset);
                //measureString = item.Monto.ToString("##,#0");
                //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                //graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
                //Offset = Offset + 16;

                totalventastarjeta += item.Monto;
            }
            //underline

            totalventas += totalventastarjeta;

            measureString = underline;
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 16;

            //   MessageBox.Show("Total venta tarjetas " + totalventastarjeta + " jean" + tarjeta);

            graphics.DrawString("TOTAL VTAS. TARJ.", stringFont, sb, startX, startY + Offset);
            measureString = tarjeta.ToString("##,#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 32;

            TOTALINGRESOS += totalventastarjeta;
            //    }
            decimal TotalVentasFinal = TOTALINGRESOS;

            this.OpenConn();


            var bus = (from xy in db.ObtieneVentas_Vw
                       //join eq in db.Equipos on x.EquipoId equals eq.Id
                       //join m in db.Movimientos on x.MovimientoId equals m.Id
                       //join u in db.Usuarios on xy.UsuarioId equals u.Id
                       //where x.MovimientoId == 2 //&& x.Activo==true 
                       where xy.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString())
                       orderby xy.Id descending
                       select new
                       {
                           //xy.UsuarioId,
                           xy.TipoPago,
                           ClienteId = xy.ClienteId,
                           xy.Id,
                           Nombre = xy.Nombre,
                           Descuento = xy.Descuento == null ? Convert.ToDecimal("0.00") : xy.Descuento,
                           //Impuesto = xy.Impuesto == null ? "0.00" : xy.Impuesto.ToString(),
                           Total = xy.Total,
                           Fecha1 = xy.Fecha.ToShortDateString(),
                           xy.Fecha,
                           xy.Hora,
                           xy.Activo,
                           //Vendedor = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido)
                           //   Monto==null?x.Monto:x.Monto 
                       });



            decimal descuento = 0;
            decimal total = 0;

            foreach (var item in bus)
            {
                descuento += Convert.ToDecimal(item.Descuento);
                //impuesto += Convert.ToDecimal(item.Impuesto);
                total += Convert.ToDecimal(item.Total);
            }

            graphics.DrawString("DESCUENTOS:", stringFont, sb, startX, startY + Offset);
            measureString = (descuento).ToString("##,#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 32;

            //Paragraph VENTASGRAVADAS = new Paragraph("VENTAS GRAVADAS: " + (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100)).ToString("##,#0.#0"), contentFont);
            //VENTASGRAVADAS.Alignment = Element.ALIGN_RIGHT;
            //VENTASGRAVADAS.IndentationRight = 50;

            //pdfDoc.Add(espacio);

            //pdfDoc.Add(VENTASGRAVADAS);


            //Paragraph VENTASEXENTAS = new Paragraph("VENTAS EXENTAS: " + (total - (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100))).ToString("##,#0.#0"), contentFont);
            //VENTASEXENTAS.Alignment = Element.ALIGN_RIGHT;
            //VENTASEXENTAS.IndentationRight = 50;
            VENTASTOTALESCajadiaria = efectivo + tarjeta;

            graphics.DrawString("TOTAL VENTAS:", stringFont, sb, startX, startY + Offset);
            measureString = (VENTASTOTALESCajadiaria).ToString("##,#0");
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 32;

            //MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos,
            //    "TOTAL DESCUENTOS: "+descuento.ToString("##,#0.#0"),
            //    "TOTAL IMPUESTOS: "+impuesto.ToString("##,#0.#0"),
            //    "TOTAL EN VENTAS: " + total.ToString("##,#0.#0"), 
            //    "",



            graphics.DrawString("FIRMA: ", stringFont, sb, startX, startY + Offset);
            Offset = Offset + 16;

            measureString = underline + underline;
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 16;


            measureString = "USUARIO: ";
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(measureString, stringFont, sb, startX, startY + Offset);

            measureString = underline + underline;
            stringSize = e.Graphics.MeasureString(measureString, stringFont);
            graphics.DrawString(_Usuario, stringFont, sb, (250 - stringSize.Width), startY + Offset);
            Offset = Offset + 16;

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
